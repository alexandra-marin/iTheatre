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
			var StarWarsImdbId = "tt0080684";
			var service = new MoviesAPI();
			Movie movie = await service.GetMovie(StarWarsImdbId);

			movie.Title.ShouldBe("The Empire Strikes Back");
		}
	}
}

