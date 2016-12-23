using System.Threading.Tasks;
using iTheatre;
using NUnit.Framework;
using Shouldly;

namespace Integration
{
	[TestFixture()]
	public class MovieAPITests
	{
		[Test()]
		public async Task SearchingForStarWarsShouldReturnTheMovie()
		{
			var StarWarsId = "1891";
			var service = new MoviesAPI();
			Movie movie = await service.GetMovie(StarWarsId);

			movie.Title.ShouldBe("The Empire Strikes Back");
		}

		[Test()]
		public async Task SearchingForStarWarsCastShouldReturnCarrieFisher()
		{
			var StarWarsId = "1891";
			var actorName = "Carrie Fisher";
			var service = new MoviesAPI();
			Movie movie = await service.GetMovieCast(StarWarsId);

			movie.Cast.ShouldContain(x => x.Name == actorName);
		}
	}
}

