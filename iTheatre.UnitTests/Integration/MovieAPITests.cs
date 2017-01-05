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
		private string StarWarsId = "tt0080684";
		private string CarrieFisherId = "nm0000402";
		
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
		public async Task SearchingForStarWarsCastShouldReturnCarrieFisher()
		{
			var actorName = "Carrie Fisher";
			var cast = await service.GetMovieCast(StarWarsId);

			cast.ShouldContain(x => x.Name == actorName);
		}

		[Test()]
		public async Task SearchingForCarrieFisherBioShouldReturnBirthday()
		{
			var date = new DateTime(1956, 10, 21);
			var birthday = await service.GetBirthday(CarrieFisherId);

			birthday.ShouldBe(date);
		}
	}
}