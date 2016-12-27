using System.Collections.Generic;
using Newtonsoft.Json;

namespace iTheatre
{
	public class Movie
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("cast")]
		public List<Actor> Cast { get; set; }
	}
}