using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XboxReplaySDK.Models.Players;

namespace XboxReplaySDK.Models.Media.Players
{
		public class PlayerGameclips
		{
			public List<Gameclip>? Data { get; set; }
			public AdditionalGameclipsData? Additional { get; set; }
			public static PlayerGameclips? FromJson(string json) => JsonSerializer.Deserialize<PlayerGameclips>(json);
		}

		public class Gameclip
		{
			public string? Id { get; set; }
			public string? Type { get; set; }
			public string? ResourceUri { get; set; }
			public List<Locator>? Locators { get; set; }
			public ClipAttributes? Attributes { get; set; }
			public ClipProperties? Properties { get; set; }
		}

		public class Locator
		{
			public string? Url { get; set; }
			public string? Type { get; set; }
			public int? FileSize { get; set; }
			public DateTime? ExpiresAt { get; set; }
		}

		public class ClipAttributes
		{
			public Resolution? Resolution { get; set; }
			public ClipDuration? Duration { get; set; }
			public int? Framerate { get; set; }
			public DateTime? RecordedAt { get; set; }
			public DateTime? UploadedAt { get; set; }
		}

		public class Resolution
		{
			public int? Width { get; set; }
			public int? Height { get; set; }
		}

		public class ClipDuration
		{
			public int? Seconds { get; set; }
			public string? Human { get; set; }
		}

		public class ClipProperties
		{
			public Game? Game { get; set; }
			public Upload? Upload { get; set; }
		}

		public class Game
		{
			public int? Id { get; set; }
			public string? Title { get; set; }
			public string? ResourceUri { get; set; }
		}

		public class Upload
		{
			public string? Device { get; set; }
			public string? Language { get; set; }
		}

		public class AdditionalGameclipsData
		{
			public Resources? Resources { get; set; }
			public Metadata? Metadata { get; set; }
			public Pagination? Pagination { get; set; }
		}

		public class Pagination
		{
			public Next? Next { get; set; }
		}

		public class Next
		{
			public string? Url { get; set; }
			public Query? Query { get; set; }
		}

		public class Query
		{
			public int? Count { get; set; }
			public string? Cursor { get; set; }
		}
	}
