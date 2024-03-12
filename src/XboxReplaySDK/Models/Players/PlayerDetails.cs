using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XboxReplaySDK.Models.Players
{
	public class PlayerDetails
	{
		public PlayerData? Data { get; set; }
		public AdditionalData? Additional { get; set; }
		public static PlayerDetails? FromJson(string _json) => JsonSerializer.Deserialize<PlayerDetails>(_json);
	}

	public class PlayerData
	{
		public string? Gamertag { get; set; }
		public string? ResourceUri { get; set; }
		public PlayerAttributes? Attributes { get; set; }
	}

	public class PlayerAttributes
	{
		public string? GamerpicUrl { get; set; }
		public int Gamerscore { get; set; }
		public PlayerColors? Colors { get; set; }
	}

	public class PlayerColors
	{
		public string? Primary { get; set; }
		public string? Secondary { get; set; }
		public string? Tertiary { get; set; }
	}

	public class AdditionalData
	{
		public ResourceLinks? Resources { get; set; }
		public ExtraData? Extra { get; set; }
	}

	public class ResourceLinks
	{
		public ResourceLink? Gameclips { get; set; }
		public ResourceLink? Screenshots { get; set; }
	}

	public class ResourceLink
	{
		public string? ResourceUri { get; set; }
	}

	public class ExtraData
	{
		public string? UserId { get; set; }
		public List<string>? Tags { get; set; }
	}
}
