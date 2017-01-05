using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace iTheatre
{
	public class MoviesAPI : IMoviesAPI
	{
		private static readonly string baseAddress = "http://www.imdb.com/";
		private static readonly string nowPlayingPath = "movies-in-theaters";
		private static readonly string movieCastPath = "/title/";
		private static readonly string actorPath = "name/";

		private WebHelper client = new WebHelper();
		private HtmlParser parser = new HtmlParser();

		public async Task<List<Movie>> GetNowPlaying()
		{
			var address = baseAddress + nowPlayingPath;
			var html = await client.Get(address);

			return parser.ReturnNowPlayingMoviesFrom(html);		
		}

		public async Task<List<Actor>> GetMovieCast(string movieId)
		{
			var address = baseAddress + movieCastPath + movieId;
			var html = await client.Get(address);

			return parser.ReturnCastFrom(html);
		}

		public async Task<DateTime> GetBirthday(string personId)
		{
			var address = baseAddress + actorPath + personId;
			var html = await client.Get(address);

			return parser.ReturnDateFrom(html);
		}
	}
}
