using System.Collections.Generic;
using Newtonsoft.Json;

namespace iTheatre
{
	public class Movie
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("cast")]
		public List<Actor> Cast { get; set; }
	}
}