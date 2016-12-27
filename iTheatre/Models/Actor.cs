using System;
using Newtonsoft.Json;

namespace iTheatre
{
	public class Actor
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("birthday")]
		public DateTime Birthday { get; set; }
	}
}