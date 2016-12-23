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

		[JsonProperty("release_date")]
		public DateTime Released { get; set; }
		public bool PlayingOn(DateTime time) => time >= Released && time <= Released.AddMonths(1);
		
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