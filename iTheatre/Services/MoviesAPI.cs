using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iTheatre
{
	public class MoviesAPI
	{
		private HttpClient client;

		private const string baseAddress = "http://www.omdbapi.com/";
		private const string findByPath = "?plot=short&r=json&t=";

		public MoviesAPI()
		{
			client = new HttpClient();
		}

		public async Task<Movie> GetMovie(string query)
		{
			string json;

			using (HttpResponseMessage response = await client.GetAsync(baseAddress + findByPath + query))
			using (HttpContent content = response.Content)
			{
				json = await content.ReadAsStringAsync();
			}

			return JsonConvert.DeserializeObject<Movie>(json);
		}
	}
}
