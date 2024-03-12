using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XboxReplaySDK
{
	internal static class Enums
	{
		public enum ResultSorting
		{
			[Description("Sorts results A-Z")]
			Ascending,
			[Description("Sorts results Z-A")]
			Descending
		}

		public enum ResultOrderBy
		{
			[Description("Results are put in order of Release Date from newest to oldest.")]
			ReleaseDate,
			[Description("Results are put in order of name (Title) from A-Z.")]
			Title
		}

		public static Dictionary<string, string> GetEnumAsQueryParam = new()
		{
			{ "ReleaseDate", "release_date" },
			{ "Title", "title" },
			{ "Ascending", "asc" },
			{ "Descending", "desc" }
		};
	}
}
