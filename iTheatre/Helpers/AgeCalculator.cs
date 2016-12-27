using System;
using System.Collections.Generic;
using System.Linq;

namespace iTheatre
{
	public class AgeCalculator
	{
		public float ReturnAverageAge(List<Actor> cast, DateTime atTime)
		{
			var averageAge =
				cast?.Count > 0 ?
					(float) cast.Sum(x => CalculateAge(atTime, x.Birthday)) / cast.Count :
					0;

			return averageAge;
		}

		private int CalculateAge(DateTime atTime, DateTime birthday)
		{
			var age = atTime.Year - birthday.Year;

			if (atTime.Month < birthday.Month || atTime.Month == birthday.Month && atTime.Day < birthday.Day)
				age--;
			
			return age;
		}
	}
}
