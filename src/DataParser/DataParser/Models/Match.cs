using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataParser.Enums;

namespace DataParser.Models
{
    public class Match : BaseModel
	{
		[Key]
		public int Id { get; set; }

		public string Slug { get; set; }

		[ForeignKey("Team1")]
		public int Team1Id { get; set; }

		public Team? Team1 { get; set; }

		[ForeignKey("Team2")]
		public int Team2Id { get; set; }

		public Team? Team2 { get; set; }

		[ForeignKey("WinnerTeam")]
		public int? WinnerTeamId { get; set; }

		public Team? WinnerTeam {  get; set; }

		[ForeignKey("LoserTeam")]
		public int? LoserTeamId { get; set; }

		public Team? LoserTeam {  get; set; }

		public int Team1Score { get; set; }

		public int Team2Score { get; set; }

		public MatchStatusEnum Status { get; set; }

		public int BOType { get; set; }

		public DateTimeOffset StartDate { get; set; }

		public DateTimeOffset EndDate { get; set; }

		public ParsedStatusEnum ParsedStatus { get; set; }

		public string? Url { get; set; }

		public string? DemoUrl { get; set; }

		public List<Map>? Maps { get; set; }

		public DisciplineEnum Discipline { get; set; }

		[ForeignKey("Tournament")]
		public int TournamentID { get; set; }

		public Tournament? Tournament { get; set; }
	}
}
