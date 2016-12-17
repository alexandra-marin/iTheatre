using System.Collections.Generic;
using System.Linq;

namespace iTheatre
{
	public class Movie
	{
		public List<Actor> Actors { get; set; } = new List<Actor>();
		public float AverageAge => Actors.Sum(x => x.Age) / Actors.Count;
	}
}