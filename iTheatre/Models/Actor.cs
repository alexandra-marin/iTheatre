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
		private DateTime birthday;
		public DateTime Birthday
		{
			get
			{
				return birthday;
			}
			set
			{
				birthday = value;
				CalculateAge();
			}
		}

		private int age;
		public int Age
		{
			get
			{
				return age;
			}
			set
			{
				age = value;
			}
		}

		private void CalculateAge()
		{
			age = DateTime.Now.Year - Birthday.Year;
		}
	}
}