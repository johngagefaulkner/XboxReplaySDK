using XboxReplaySDK;

internal class Program
{
	private static async Task Main(string[] args)
	{
		DisplayConsoleHeader();
		XboxReplayClient.Configure(GetUserAPIKey());

		var playerDetails = await XboxReplayClient.API.Players.GetPlayerDetailsAsync("Iocalhost");

		var _gamerPicture = playerDetails?.Data?.Attributes?.GamerpicUrl;
		var _gamerScore = playerDetails?.Data?.Attributes?.Gamerscore;
		var _gamertag = playerDetails?.Data?.Gamertag;

		Console.WriteLine($"Gamertag: {_gamertag}");
		Console.WriteLine($"GamerScore: {_gamerScore}");
		Console.WriteLine($"GamerPicture: {_gamerPicture}");
		Console.WriteLine();

		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Obtaining Player's Recently Played items...");
		Console.ResetColor();
		var _recentlyPlayed = await XboxReplayClient.API.Players.GetPlayerRecentlyPlayedAsync("Iocalhost");
		Console.WriteLine($"Done! {_recentlyPlayed?.Data?.Count} items found.");

		if (_recentlyPlayed?.Data is not null)
		{
			foreach (var _item in _recentlyPlayed.Data)
			{
				Console.WriteLine($"Title: {_item.Title} ({_item.Id})");
			}
		}
		Console.WriteLine();
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Retrieving Player's Game Clips...");
		Console.ResetColor();
		var _gameclips = await XboxReplayClient.API.Media.Players.GetPlayerGameClipsAsync("Iocalhost");
		Console.WriteLine($"Done! {_gameclips?.Data?.Count} clips found.");

		if (_gameclips is not null)
		{
			if (_gameclips.Data is not null)
			{
				foreach (var _clip in _gameclips.Data)
				{
					var clipStr = $"Clip ID: {_clip.Id} ({_clip.Attributes.Resolution.Height}p{_clip.Attributes.Framerate})";
					Console.WriteLine(clipStr);
				}
			}
		}

		Console.WriteLine("Press any key to exit...");
		Console.ReadKey();
		Environment.Exit(0);
	}

	private static void DisplayConsoleHeader()
	{
		Console.Title = "XboxReplaySDK: Console Test App";
		Console.Clear();
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("======== XboxReplaySDK: Console Test App ========");
		Console.WriteLine();
		Console.ResetColor();
	}

	private static string GetUserAPIKey()
	{
		Console.Write("Enter your XboxReplay API Key: ");
		var userResponse = Console.ReadLine();
		if (!string.IsNullOrEmpty(userResponse))
		{
			userResponse = userResponse.Trim();
		}
		else
		{
			Console.WriteLine("You must enter an API Key to continue.");
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
			Environment.Exit(0);
		}

		return userResponse;
	}
}