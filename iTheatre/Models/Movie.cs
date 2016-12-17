using System.Collections.Generic;
using System.Linq;

namespace iTheatre
{
	public class Movie
	{
		private float averageAge;
		public float AverageAge => averageAge;

		public Movie(List<Actor> actors)
		{ 
			averageAge = actors.Sum(x => x.Age) / actors.Count;
		}
	}
}