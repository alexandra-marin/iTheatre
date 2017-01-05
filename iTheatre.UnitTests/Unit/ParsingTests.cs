using System;
using Shouldly;
using NUnit.Framework;
using iTheatre;

namespace Unit
{
	[TestFixture()]
	public class ParsingTests
	{
		HtmlParser parser;

		[SetUp]
		public void Init()
		{
			parser = new HtmlParser();
		}

		[Test()]
		public void NowPlayingInputFormatContainsMovie()
		{
			var expectedMovieTitle = "Rogue One: A Star Wars Story (2016)";

			var input = "<h4 itemprop=\"name\"><a href=\"/title/tt3748528/?ref_=inth_ov_tt\"\ntitle=\"Rogue One: A Star Wars Story (2016)\" itemprop='url'> Rogue One: A Star Wars Story (2016)</a></h4>\n";

			var movies = parser.ReturnNowPlayingMoviesFrom(input);

			movies.ShouldContain(x => x.Title == expectedMovieTitle);
		}

		[Test()]
		public void MovieCastInputFormatReturnsListOfActors()
		{
			string expectedActorName = "Felicity Jones";

			var input = "<table class=\"cast_list\"> \n\n<tr>\n\n\n\n\n\n\n\n\n\n<td class=\"itemprop\" itemprop=\"actor\" itemscope itemtype=\"http://schema.org/Person\">\n\n<a href=\"/name/nm0428065/?ref_=tt_cl_t1\"\n\nitemprop='url'> <span class=\"itemprop\" itemprop=\"name\">Felicity Jones</span>\n\n</a> </td>\n\n\n</tr>\n</table>";

			var actors = parser.ReturnCastFrom(input);

			actors.ShouldContain(x => x.Name == expectedActorName);
		}

		[Test()]
		public void ActorBioInputFormatReturnsBirthdate()
		{
			var expectedDate = new DateTime(1956, 10, 21);

			var input = "<time datetime=\"1956-10-21\" itemprop=\"birthDate\">\n<a href=\"/search/name?birth_monthday=10-21&amp;refine=birth_monthday&amp;ref_=nm_ov_bth_monthday\">October 21</a>, \n     \n<a href=\"/search/name?birth_year=1956&amp;ref_=nm_ov_bth_year\">1956</a>    \n  </time>";
		
			var birthdate = parser.ReturnDateFrom(input);

			birthdate.ShouldBe(expectedDate);
		}
	}
}
