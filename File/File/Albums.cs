using System;
using System.Text.Json.Serialization;
namespace File
{
	public class Albums
	{
		[JsonPropertyName("userId")]
		public int UserId { get; set; }

	     [JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("title")]
		public string Title { get; set; }

        public override string ToString()
        {
			return $"{UserId}-{Id}-{Title}";
        }
    }
}

