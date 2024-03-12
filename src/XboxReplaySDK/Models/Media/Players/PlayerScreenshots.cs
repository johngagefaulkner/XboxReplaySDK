using XboxReplaySDK.Models.Players;

namespace XboxReplaySDK.Models.Media.Players
{
	public class PlayerScreenshots
	{
		public List<Screenshot>? Data { get; set; }
		public AdditionalScreenshotData? Additional { get; set; }
		public static PlayerScreenshots? FromJson(string json) => JsonSerializer.Deserialize<PlayerScreenshots>(json);
	}

	public class Screenshot
	{
		public string? Id { get; set; }
		public string? Type { get; set; }
		public string? ResourceUri { get; set; }
		public List<Locator>? Locators { get; set; }
		public ScreenshotAttributes? Attributes { get; set; }
		public ScreenshotProperties? Properties { get; set; }
	}

	// Locator remains the same as in the PlayerGameclips model

	public class ScreenshotAttributes
	{
		public Resolution? Resolution { get; set; }
		public DateTime? CapturedAt { get; set; }
		public DateTime? UploadedAt { get; set; }
	}

	// Resolution remains as before

	public class ScreenshotProperties
	{
		public Game? Game { get; set; }
		public Upload? Upload { get; set; }
	}

	// Game and Upload remain the same

	public class AdditionalScreenshotData
	{
		public Resources? Resources { get; set; }
		public Metadata? Metadata { get; set; }
		public Pagination? Pagination { get; set; }
	}

	// Resources, Metadata, Pagination structures remain the same
}
