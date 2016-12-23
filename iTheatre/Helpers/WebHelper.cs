using System.Net.Http;
using System.Threading.Tasks;

namespace iTheatre
{
	public class WebHelper
	{
		private HttpClient client = new HttpClient();

		public async Task<string> Get(string address)
		{
			using (HttpResponseMessage response = await client.GetAsync(address))
			using (HttpContent content = response.Content)
			{
				return await content.ReadAsStringAsync();
			}
		}
	}
}
