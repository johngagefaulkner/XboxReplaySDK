using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XboxReplaySDK.Models.Players
{
	public class PlayerPresence
	{
		public PlayerPresenceData? Data { get; set; }
		public AdditionalPresenceData? Additional { get; set; }

		public static PlayerPresence? FromJson(string json) => JsonSerializer.Deserialize<PlayerPresence>(json);
	}

	public class PlayerPresenceData
	{
		public string? Text { get; set; }
		public bool Online { get; set; }
	}

	public class AdditionalPresenceData
	{
		public Resources? Resources { get; set; }
	}

	public class Resources
	{
		public Player? Player { get; set; }
	}

	public class Player
	{
		public string? Gamertag { get; set; }
		public string? ResourceUri { get; set; }
	}
}
