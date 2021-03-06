﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace iTheatre
{
	public class AgeCalculator
	{
		public float ReturnAverageAge(List<Actor> cast, DateTime atTime)
		{
			var averageAge = 0f;

			if(cast?.Count > 0)
			{
				var validAges = cast.Where(x => x.Birthday != default(DateTime)).ToList();
				if(validAges.Count > 0)
				{
					averageAge = (float) validAges.Sum(x => CalculateAge(atTime, x.Birthday)) / validAges.Count;
				}
			}

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
