using Newtonsoft.Json;

namespace iTheatre
{
	public class Actor
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		public int Age { get; set; }
	}
}