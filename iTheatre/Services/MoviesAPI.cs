using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iTheatre
{
	public class MoviesAPI : IMoviesAPI
	{
		private static readonly string baseAddress = "https://api.themoviedb.org/3/";
		private static readonly string moviePath = "movie/";
		private static readonly string movieCastPath = "/credits";
		private static readonly string apiKey = string.Format("?api_key={0}", Credentials.MDBIKey);

		private WebHelper client = new WebHelper();

		public async Task<Movie> GetMovie(string movieId)
		{
			var address = baseAddress + moviePath + movieId + apiKey;
			var json = await client.Get(address);

			return JsonConvert.DeserializeObject<Movie>(json);
		}

		public async Task<List<Actor>> GetMovieCast(string movieId)
		{
			var address = baseAddress + moviePath + movieId + movieCastPath + apiKey;
			var json = await client.Get(address);

			var definition = new { Cast = new List<Actor>() };
			var credits = JsonConvert.DeserializeAnonymousType(json, definition);

			return credits.Cast;
		}
	}
}
