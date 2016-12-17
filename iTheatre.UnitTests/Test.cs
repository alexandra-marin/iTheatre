using NUnit.Framework;
using iTheatre;

namespace iTheatre.UnitTests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void MovieWithOneActorHasAverageAgeOfActor()
		{
			Actor actor = new Actor();
			actor.Age = 30;

			Movie movieWithOneActor = new Movie();
			movieWithOneActor.Actors.Add(actor);

			Assert.That(movieWithOneActor.AverageAge, Is.EqualTo(30));
		}
	}
}
