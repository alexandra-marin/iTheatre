using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace iTheatre
{
	public class HtmlParser
	{
		public List<Movie> ReturnNowPlayingMoviesFrom(string input)
		{
			var htmldoc = new HtmlDocument();
			htmldoc.LoadHtml(input);

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

		public List<Actor> ReturnCastFrom(string html)
		{
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
									Name = x.Descendants("span").FirstOrDefault(s => s.Attributes["itemprop"]?.Value == "name").InnerText
								})
								.ToList();

			return actors;
		}

		public DateTime ReturnDateFrom(string html)
		{
			var date = default(DateTime);

			var htmldoc = new HtmlDocument();
			htmldoc.LoadHtml(html);

			try
			{
				var birthDate = htmldoc.DocumentNode
									.Descendants("time")
									.First(x => x.Attributes["itemprop"]?.Value == "birthDate")
									.Attributes["datetime"]?.Value;

				DateTime.TryParse(birthDate, out date);
			}
			catch (Exception e) { }

			return date;
		}
	}
}
