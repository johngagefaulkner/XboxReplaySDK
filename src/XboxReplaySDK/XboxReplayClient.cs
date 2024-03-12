global using System;
global using System.Collections.Generic;
global using System.Collections.Specialized;
global using System.Diagnostics;
global using System.Globalization;
global using System.IO;
global using System.Linq;
global using System.Net;
global using System.Net.Http;
global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Threading.Tasks;

global using XboxReplaySDK;
global using XboxReplaySDK.Models;

using System.Security.Cryptography.X509Certificates;

using XboxReplaySDK.Models.Media.Players;
using XboxReplaySDK.Models.Players;

namespace XboxReplaySDK
{
	public static class XboxReplayClient
	{
		private static bool _isInitialized { get; set; } = false;
		private static readonly HttpClient _httpClient = new();

		public static void Configure(string apiKey)
		{
			if (!string.IsNullOrEmpty(apiKey))
			{
				_httpClient.BaseAddress = new Uri("https://api.v2.xboxreplay.net");
				_httpClient.DefaultRequestVersion = new Version(2, 0);
				_httpClient.Timeout = TimeSpan.FromSeconds(30);
				_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
				_httpClient.DefaultRequestHeaders.Add("API-Version", "2023-12-28");
				_httpClient.DefaultRequestHeaders.Add("User-Agent", "Iocalhost");
				
				_isInitialized = true;
			}

			else
			{
				throw new InvalidOperationException("API Key must be set before using XboxReplayClient.");
			}
		}

		public static class API
		{
			public static class Players
			{
				public static async Task<PlayerDetails?> GetPlayerDetailsAsync(string gamertag) => await _httpClient.GetFromJsonAsync<PlayerDetails>(Endpoints.Players.GetPlayerDetailsEndpoint(gamertag));

				public static async Task<PlayerPresence?> GetPlayerPresenceAsync(string gamertag) => await _httpClient.GetFromJsonAsync<PlayerPresence>(Endpoints.Players.GetPlayerPresenceEndpoint(gamertag));

				public static async Task<PlayerRecentlyPlayed?> GetPlayerRecentlyPlayedAsync(string gamertag) => await _httpClient.GetFromJsonAsync<PlayerRecentlyPlayed>(Endpoints.Players.GetPlayerRecentlyPlayedEndpoint(gamertag));
			}

			public static class Media
			{
				public static class Games
				{
					public static async Task<Models.Media.Games.GameGameclips?> GetGameClipsAsync(string titleId) => await _httpClient.GetFromJsonAsync<Models.Media.Games.GameGameclips>(Endpoints.Media.Games.GetGameClipsEndpoint(titleId));
				}

				public static class Players
				{
					public static async Task<PlayerGameclips?> GetPlayerGameClipsAsync(string gamertag) => await _httpClient.GetFromJsonAsync<PlayerGameclips>(Endpoints.Media.Players.GetPlayerGameclipsEndpoint(gamertag));

					public static async Task<PlayerScreenshots?> GetPlayerScreenshotsAsync(string gamertag) => await _httpClient.GetFromJsonAsync<PlayerScreenshots>(Endpoints.Media.Players.GetPlayerScreenshotsEndpoint(gamertag));
				}
			}
		}
	}
}
