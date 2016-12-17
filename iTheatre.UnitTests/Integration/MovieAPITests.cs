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
			var service = new MoviesAPI();
			Movie movie = await service.GetMovie("Star Wars");

			movie.ShouldNotBe(default(Movie));
		}
	}
}

