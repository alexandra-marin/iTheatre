using System;
using System.Collections.Generic;
using System.Linq;

namespace iTheatre
{
	public class Movie
	{
		private float averageAge;
		public float AverageAge => averageAge;

		public DateTime StartDate;
		public DateTime EndDate;
		
		public Movie(List<Actor> actors)
		{
			averageAge =
				actors?.Count > 0 ?
					(float) actors.Sum(x => x.Age) / actors.Count :
			    	0;
		}

		public bool InTheatreNow(DateTime time) => time >= StartDate && time <= EndDate;
	}
}