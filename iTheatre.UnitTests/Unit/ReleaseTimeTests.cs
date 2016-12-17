using System;
using System.Threading.Tasks;
using FakeItEasy;
using iTheatre;
using NUnit.Framework;
using Shouldly;

namespace Unit
{
	[TestFixture()]
	public class ReleaseTimeTests
	{
		[Test()]
		public async Task StarWarsEpisodeVPlaysInTheWeekOf20June1980()
		{
			var service = A.Fake<IMoviesAPI>();

			Movie returnedMovie = new Movie() { Released = new DateTime(1980, 6, 20) };
			A.CallTo(() => service.GetMovie(A<string>.Ignored)).Returns(returnedMovie);

			DateTime time = new DateTime(1980, 6, 21);
			var movie = await service.GetMovie("Empire strikes back");

			movie.PlayingOn(time).ShouldBeTrue();
		}
	}
}

