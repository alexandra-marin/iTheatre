using NUnit.Framework;
using System.Collections.Generic;

namespace iTheatre.UnitTests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void MovieWithOneActorHasAverageAgeOfActor()
		{
			var actorsList = new List<Actor>();
			actorsList.Add( new Actor() { Age = 30 } );
			
			Movie movieWithOneActor = new Movie(actorsList);

			Assert.That(movieWithOneActor.AverageAge, Is.EqualTo(30));
		}
	}
}
