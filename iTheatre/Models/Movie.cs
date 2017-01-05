using System.Collections.Generic;

namespace iTheatre
{
	public class Movie
	{
		public string Id { get; set; }

		public string Title { get; set; }

		public List<Actor> Cast { get; set; }
	}
}