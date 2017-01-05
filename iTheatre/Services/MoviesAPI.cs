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

		public async Task<List<Movie>> GetNowPlaying()
		{
			var address = baseAddress + nowPlayingPath;
			var html = await client.Get(address);

			var htmldoc = new HtmlDocument();
			htmldoc.LoadHtml(html);

			var movies = htmldoc.DocumentNode
			                    .Descendants("h4")
			                    .Select(d => d.Descendants("a").FirstOrDefault())
								.Select(x => new Movie()
								{
									Title = x.Attributes["title"]?.Value,
									Id = Regex.Match(x.Attributes["href"]?.Value, @"\/title\/(.*?)\/\?").Groups[1].Value
								})
			                    .ToList();

			return movies;		
		}

		public async Task<List<Actor>> GetMovieCast(string movieId)
		{
			var address = baseAddress + movieCastPath + movieId;
			var html = await client.Get(address);

			var htmldoc = new HtmlDocument();
			htmldoc.LoadHtml(html);

			var actors = htmldoc.DocumentNode
								.Descendants("table")
								.First(x => x.Attributes["class"]?.Value == "cast_list")
								.Descendants()
								.Where(d => d.Attributes["itemprop"]?.Value == "actor")
								.Select(x => new Actor()
								{
									Id = Regex.Match(x.Descendants("a").FirstOrDefault().Attributes["href"]?.Value, @"\/name\/(.*?)\/\?").Groups[1].Value,
									Name = x.Descendants("span").FirstOrDefault( s=> s.Attributes["itemprop"]?.Value == "name").InnerText
								})
								.ToList();

			return actors;
		}

		public async Task<DateTime> GetBirthday(string personId)
		{
			var address = baseAddress + actorPath + personId;
			var html = await client.Get(address);

			var htmldoc = new HtmlDocument();
			htmldoc.LoadHtml(html);

			var date = default(DateTime);
			try
			{
				var birthDate = htmldoc.DocumentNode
									.Descendants("time")
									.First(x => x.Attributes["itemprop"]?.Value == "birthDate")
									.Attributes["datetime"]?.Value;

				DateTime.TryParse(birthDate, out date);
			}
			catch (Exception e) {}

			return date;
		}
	}
}
