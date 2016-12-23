using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iTheatre
{
	public class MoviesAPI : IMoviesAPI
	{
		private HttpClient client;

		private static readonly string baseAddress = "https://api.themoviedb.org/3/";
		private static readonly string moviePath = "movie/";
		private static readonly string apiKey = string.Format("?api_key={0}", Credentials.MDBIKey);

		public MoviesAPI()
		{
			client = new HttpClient();
		}

		public async Task<Movie> GetMovie(string movieId)
		{
			string json;
			var address = baseAddress + moviePath + movieId + apiKey;

			using (HttpResponseMessage response = await client.GetAsync(address))
			using (HttpContent content = response.Content)
			{
				json = await content.ReadAsStringAsync();
			}

			return JsonConvert.DeserializeObject<Movie>(json);
		}
	}
}
