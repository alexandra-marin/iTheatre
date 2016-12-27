using System;
using System.Threading.Tasks;
using iTheatre;
using NUnit.Framework;
using Shouldly;

namespace Integration
{
	[TestFixture()]
	public class MovieAPITests
	{
		private IMoviesAPI service;
		private string StarWarsId = "1891";

		[SetUp]
		public void Init()
		{
			service = new MoviesAPI();
		}

		[Test()]
		public async Task RequestingNowPlayingShouldReturnListOfMovies()
		{
			var movies = await service.GetNowPlaying();

			movies.ShouldNotBeEmpty();
		}

		[Test()]
		public async Task SearchingForStarWarsShouldReturnTheMovie()
		{
			Movie movie = await service.GetMovie(StarWarsId);

			movie.Title.ShouldBe("The Empire Strikes Back");
		}

		[Test()]
		public async Task SearchingForStarWarsCastShouldReturnCarrieFisher()
		{
			var actorName = "Carrie Fisher";
			var cast = await service.GetMovieCast(StarWarsId);

			cast.ShouldContain(x => x.Name == actorName);
		}

		[Test()]
		public async Task SearchingForCarrieFisherBioShouldReturnBirthday()
		{
			var actorId = "4";
			var date = new DateTime(1956, 10, 21);
			var birthday = await service.GetBirthday(actorId);

			birthday.ShouldBe(date);
		}
	}
}