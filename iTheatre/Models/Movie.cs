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

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("cast")]
		private List<Actor> cast { get; set; }
		public List<Actor> Cast 
		{ 
			get
			{
				return cast;
			}
			set
			{
				cast = value;
				CalculateAverageAge();
			}
		}

		private void CalculateAverageAge()
		{
			averageAge =
				cast?.Count > 0 ?
					(float)cast.Sum(x => x.Age) / cast.Count :
					0;
		}
	}
}