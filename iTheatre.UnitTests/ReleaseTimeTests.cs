using System.Collections.Generic;
using NUnit.Framework;
using System;

namespace iTheatre.UnitTests
{
	[TestFixture()]
	public class ReleaseTimeTests
	{
		[Test()]
		public void StarWarsEpisodeVIsReleasedInTheWeekOf20June1980 ()
		{
			DateTime time = new DateTime(1980, 6, 20);

			Movie movie = new Movie(new List<Actor>());
			movie.StartDate = new DateTime(1980, 6, 20);
			movie.EndDate = new DateTime(1980, 7, 20);

			Assert.That(movie.InTheatreNow(time), Is.True);
		}
	}
}
