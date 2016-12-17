using System.Collections.Generic;
using NUnit.Framework;

namespace iTheatre.UnitTests
{
	[TestFixture()]
	public class AverageAgeTests
	{
		[Test()]
		public void MovieWithOneActorHasAverageAgeOfActor()
		{
			var actorsList = new List<Actor>();
			actorsList.Add( new Actor() { Age = 30 } );
			
			Movie movieWithOneActor = new Movie(actorsList);

			Assert.That(movieWithOneActor.AverageAge, Is.EqualTo(30));
		}

		[Test()]
		public void MovieWithNoActorsHasAverageAgeEqualTo0()
		{
			var actorsList = new List<Actor>();

			Movie movieWithOneActor = new Movie(actorsList);

			Assert.That(movieWithOneActor.AverageAge, Is.EqualTo(0));
		}

		[Test()]
		public void MovieWithTwoActorsHasAverageAgeEqualToMean()
		{
			var actorsList = new List<Actor>();
			actorsList.Add(new Actor() { Age = 1 });
			actorsList.Add(new Actor() { Age = 2 });

			Movie movie = new Movie(actorsList);

			Assert.That(movie.AverageAge, Is.EqualTo(1.5));
		}
	}
}
