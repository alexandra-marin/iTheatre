using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace iTheatre.Tests
{
	[TestFixture()]
	public class ReleaseTimeTests
	{
		[Test()]
		public async Task StarWarsEpisodeVIsReleasedInTheWeekOf20June1980()
		{
			DateTime time = new DateTime(1980, 6, 20);

			var service = new MoviesAPI();
			Movie movie = await service.GetMovie("Empire strikes back");

			Assert.That(movie.InTheatreNow(time), Is.True);
		}
	}
}

