using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using iTheatre;
using NUnit.Framework;
using Shouldly;

namespace Unit
{
	[TestFixture()]
	public class AverageAgeTests
	{
		[Test()]
		public void MovieWithOneActorHasAverageAgeOfActor()
		{
			var actorsList = new List<Actor>();
			actorsList.Add( new Actor() { Birthday = DateTime.Now.AddYears(-30) } );
			
			Movie movieWithOneActor = new Movie();
			movieWithOneActor.Cast = actorsList;

			movieWithOneActor.AverageAge.ShouldBe(30);
		}

		[Test()]
		public void MovieWithNoActorsHasAverageAgeEqualTo0()
		{
			var actorsList = new List<Actor>();

			Movie movieWithNoActors = new Movie();
			movieWithNoActors.Cast = actorsList;
			
			movieWithNoActors.AverageAge.ShouldBe(0);
		}

		[Test()]
		public void MovieWithTwoActorsHasAverageAgeEqualToMean()
		{
			var actorsList = new List<Actor>();
			actorsList.Add(new Actor() { Birthday = DateTime.Now.AddYears(-1) });
			actorsList.Add(new Actor() { Birthday = DateTime.Now.AddYears(-2) });

			Movie movie = new Movie();
			movie.Cast = actorsList;
			
			movie.AverageAge.ShouldBe(1.5f);
		}

		[Test()]
		public async Task StarWarsAverageAgeIs()
		{
			var service = A.Fake<IMoviesAPI>();

			var starWarsMovie = new Movie();
			var starWarsCast = new List<Actor>();

			var markHamill   = new Actor() { Id = "1", Birthday = new DateTime(1951, 09, 25) };
			var harrisonFord = new Actor() { Id = "2", Birthday = new DateTime(1942, 07, 13) };
			var carrieFisher = new Actor() { Id = "3", Birthday = new DateTime(1956, 10, 21) };
			var davidProwse  = new Actor() { Id = "4", Birthday = new DateTime(1935, 07, 01) };

			starWarsCast.Add(markHamill);
			starWarsCast.Add(harrisonFord);
			starWarsCast.Add(carrieFisher);
			starWarsCast.Add(davidProwse);

			var averageAge = starWarsCast.Sum(x => DateTime.Now.Year - x.Birthday.Year)
                         	 / starWarsCast.Count();

			A.CallTo(() => service.GetMovie(A<string>.Ignored)).Returns(starWarsMovie);
			A.CallTo(() => service.GetMovieCast(A<string>.Ignored)).Returns(starWarsCast);

			A.CallTo(() => service.GetBirthday(markHamill  .Id)).Returns(markHamill  .Birthday);
			A.CallTo(() => service.GetBirthday(harrisonFord.Id)).Returns(harrisonFord.Birthday);
			A.CallTo(() => service.GetBirthday(carrieFisher.Id)).Returns(carrieFisher.Birthday);
			A.CallTo(() => service.GetBirthday(davidProwse .Id)).Returns(davidProwse .Birthday);

			var movieId = A.Dummy<string>();

			var movie = await service.GetMovie(movieId);
			var cast = await service.GetMovieCast(movieId);
			movie.Cast = cast;

			movie.AverageAge.ShouldBe(averageAge);
		}
	}
}
