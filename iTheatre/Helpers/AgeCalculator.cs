using System;
using System.Collections.Generic;
using System.Linq;

namespace iTheatre
{
	public class AgeCalculator
	{
		public object ReturnAverageAge(List<Actor> cast, DateTime atTime)
		{
			var averageAge =
				cast?.Count > 0 ?
					(float)cast.Sum(x => atTime.Year - x.Birthday.Year) / cast.Count :
					0;
			
			return averageAge;
		}
	}
}
