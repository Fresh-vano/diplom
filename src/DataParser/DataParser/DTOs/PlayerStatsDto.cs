using Newtonsoft.Json;

namespace DataParser.DTOs
{
	public class PlayerStatsDto
	{
		public List<StatsDto> stats;
	}

	public class StatsDto 
	{
		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("game_id")]
		public long MapId { get; set; }

		[JsonProperty("steam_profile")]
		public NestedPlayerDto PlayerId { get; set; }

		[JsonProperty("team_clan")]
		public NestedTeamDto TeamId { get; set; }

		[JsonProperty("win")]
		public int Win { get; set; }

		[JsonProperty("kills")]
		public int Kills { get; set; }

		[JsonProperty("assists")]
		public int Assists { get; set; }

		[JsonProperty("death")]
		public int Death { get; set; }

		[JsonProperty("adr")]
		public double Adr { get; set; }

		[JsonProperty("additional_value")]
		public int AdditionalValue { get; set; }

		[JsonProperty("clutches")]
		public int Clutches { get; set; }

		[JsonProperty("cumulative_round_damages")]
		public Dictionary<int, int> CumulativeRoundDamages { get; set; }

		[JsonProperty("damage")]
		public int Damage { get; set; }

		[JsonProperty("first_kills")]
		public int FirstKills { get; set; }

		[JsonProperty("first_death")]
		public int FirstDeath { get; set; }

		[JsonProperty("got_damage")]
		public int GotDamage { get; set; }

		[JsonProperty("headshots")]
		public int Headshots { get; set; }

		[JsonProperty("hits")]
		public int Hits { get; set; }

		[JsonProperty("kast")]
		public double Kast { get; set; }

		[JsonProperty("money_spent")]
		public int MoneySpent { get; set; }

		[JsonProperty("money_save")]
		public int MoneySave { get; set; }

		[JsonProperty("multikills")]
		public Dictionary<int, int> Multikills { get; set; }

		[JsonProperty("pistols_value")]
		public int PistolsValue { get; set; }

		[JsonProperty("player_rating")]
		public double PlayerRating { get; set; }

		[JsonProperty("shots")]
		public int Shots { get; set; }

		[JsonProperty("total_equipment_value")]
		public int TotalEquipmentValue { get; set; }

		[JsonProperty("weapons_value")]
		public int WeaponsValue { get; set; }

		[JsonProperty("trade_death")]
		public int TradeDeath { get; set; }

		[JsonProperty("trade_kills")]
		public int TradeKills { get; set; }

		[JsonProperty("utility_value")]
		public int UtilityValue { get; set; }

		public class NestedTeamDto
		{
			[JsonProperty("team_id")]
			public int Id { get; set; }
		}

		public class NestedPlayerDto
		{
			[JsonProperty("player_id")]
			public int Id { get; set; }
		}
	}
}
