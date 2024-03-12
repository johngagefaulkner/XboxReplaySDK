using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XboxReplaySDK;

using static XboxReplaySDK.Endpoints;

namespace XboxReplaySDK
{
	internal static class Endpoints
	{
		private static int EnsureValidResultCount(int _resultCount)
		{
			var validResultCount = _resultCount;

			if (_resultCount < 1) { validResultCount = 1; }
			if (_resultCount > 100) { validResultCount = 100; }

			return validResultCount;
		}

		internal static class Games
		{
			internal static string GetGameDetailsEndpoint(string titleId) => $"/games/{titleId}";

			internal static string GetGameSearchResultsEndpoint(string searchQuery, int resultCount = 10, Enums.ResultOrderBy resultOrderBy = Enums.ResultOrderBy.Title, Enums.ResultSorting resultSort = Enums.ResultSorting.Ascending)
			{
				if (resultCount < 1) { resultCount = 1;	}
				if (resultCount > 100) { resultCount = 100;	}

				var orderBy = Enums.GetEnumAsQueryParam[resultOrderBy.ToString()];
				var sort = Enums.GetEnumAsQueryParam[resultSort.ToString()];

				return $"/games?q={searchQuery}&count={resultCount}&order={orderBy}&sort={sort}";
			}
		}

		internal static class Media
		{
			internal static class Games
			{
				internal static string GetGameClipsEndpoint(string titleId, int resultCount = 10) => $"/media/games/{titleId}/gameclips?count={EnsureValidResultCount(resultCount)}";
			}

			internal static class Players
			{
				internal static string GetPlayerGameclipsEndpoint(string gamertag, int resultCount = 10) => $"/media/players/{gamertag}/gameclips?count={EnsureValidResultCount(resultCount)}";

				internal static string GetPlayerScreenshotsEndpoint(string gamertag, int resultCount = 10) => $"/media/players/{gamertag}/screenshots?count={EnsureValidResultCount(resultCount)}";
			}
		}

		internal static class Players
		{
			internal static string GetPlayerDetailsEndpoint(string gamertag) => $"/players/{gamertag}";
			internal static string GetPlayerPresenceEndpoint(string gamertag) => $"/players/{gamertag}/presence";
			internal static string GetPlayerRecentlyPlayedEndpoint(string gamertag, int resultCount = 10) => $"/players/{gamertag}/recently-played?count={EnsureValidResultCount(resultCount)}";
		}
	}
}
