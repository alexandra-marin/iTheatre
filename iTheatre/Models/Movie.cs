using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace iTheatre
{
	public class Movie
	{
		private float averageAge;
		public float AverageAge => averageAge;

		[JsonProperty("Released")]
		private DateTime released;
		public bool InTheatreNow(DateTime time) => time >= released && time <= released.AddMonths(1);
		
		public Movie()
		{
		}

		public Movie(List<Actor> actors)
		{
			averageAge =
				actors?.Count > 0 ?
					(float) actors.Sum(x => x.Age) / actors.Count :
			    	0;
		}
	}
}