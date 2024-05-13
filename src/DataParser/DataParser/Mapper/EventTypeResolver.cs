using AutoMapper;
using DataParser.DTOs;
using DataParser.Enums;
using DataParser.Models;

public class EventTypeResolver : IValueResolver<TournamentFullDto, Tournament, EventTypeEnum?>
{
	public EventTypeEnum? Resolve(TournamentFullDto source, Tournament destination, EventTypeEnum? destMember, ResolutionContext context)
	{
		string eventTypeString = source.EventType;
		if (!string.IsNullOrEmpty(eventTypeString))
		{
			if (Enum.TryParse(eventTypeString, true, out EventTypeEnum eventType))
			{
				return eventType;
			}
		}

		return EventTypeEnum.Mixed;
	}
}