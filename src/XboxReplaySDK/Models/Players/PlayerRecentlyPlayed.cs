using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XboxReplaySDK.Models.Players
{
	public class PlayerRecentlyPlayed
	{
		public List<Game>? Data { get; set; }
		public AdditionalRecentlyPlayedData? Additional { get; set; }

		public static PlayerRecentlyPlayed? FromJson(string json) => JsonSerializer.Deserialize<PlayerRecentlyPlayed>(json);
	}

	public class Game
	{
		public int? Id { get; set; }
		public string? Title { get; set; }
		public string? ResourceUri { get; set; }
		public ImageUrls? ImageUrls { get; set; }
	}

	public class ImageUrls
	{
		public string? Hero { get; set; }
		public string? Poster { get; set; }
		public string? BoxArt { get; set; }
		public string? SquareArt { get; set; }
	}

	public class AdditionalRecentlyPlayedData
	{
		public Resources? Resources { get; set; }
		public Metadata? Metadata { get; set; }
	}

	public class Metadata
	{
		public int? Count { get; set; }
	}
}
