using AutoMapper;
using DataParser.DTOs;
using DataParser.Enums;
using DataParser.Models;
using Newtonsoft.Json;

namespace DataParser.Mapper
{
	public class EntityMapper : Profile
	{
		public EntityMapper() 
		{
			CreateMap<PlayerDto, Player>()
				.ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Country.Id));

			CreateMap<CountryDto, Country>()
				.ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Name));

			CreateMap<TeamDto, Team>()
				.ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Country.Id));

			CreateMap<TeamClanDto, TeamName>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ClanName));

			CreateMap<TournamentMinDto, Tournament>()
				.ForMember(dest => dest.Tier, opt => opt.MapFrom<TierResolver>())
				.ForMember(dest => dest.Status, opt => opt.MapFrom<StatusResolver>());

			CreateMap<TournamentFullDto, Tournament>()
				.ForMember(dest => dest.Country, opt => opt.MapFrom<CountryIdsResolver>())
				.ForMember(dest => dest.EventType, opt => opt.MapFrom<EventTypeResolver>())
				.ForMember(dest => dest.Discipline, opt => opt.MapFrom(src => (DisciplineEnum)Enum.GetValues(typeof(DisciplineEnum)).GetValue(int.Parse(src.Discipline)-1)));
		
			CreateMap<StageDto, Stage>()
				.ForMember(dest => dest.StageType, opt => opt.MapFrom<StageTypeResolver>())
				.ForMember(dest => dest.Status, opt => opt.MapFrom<StatusStageResolver>())
				.ForMember(dest => dest.Teams, opt => opt.MapFrom<TeamIdsResolver>());

			CreateMap<MatchMinDto, Match>()
				.ForMember(dest => dest.TournamentID, opt => opt.MapFrom(src => src.NestedTournament.Id))
				.ForMember(dest => dest.Status, opt => opt.MapFrom<MatchStatusResolver>())
				.ForMember(dest => dest.ParsedStatus, opt => opt.MapFrom<ParsedStatusResolver>());

			CreateMap<MatchFullDto, Match>();

			CreateMap<MapDto, Map>();

			CreateMap<StatsDto, PlayerStats>()
			.ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId.Id))
			.ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.TeamId.Id))
			.ForMember(dest => dest.MapId, opt => opt.MapFrom(src => src.MapId))
			.ForMember(dest => dest.CumulativeRoundDamages, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.CumulativeRoundDamages)))
			.ForMember(dest => dest.Multikills, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Multikills)));
		}
	}
}
