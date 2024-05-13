using AutoMapper;
using DataParser.DTOs;
using DataParser.Enums;
using DataParser.Models;
using System;

public class StatusResolver : IValueResolver<TournamentMinDto, Tournament, TournamentStatusEnum>
{
	public TournamentStatusEnum Resolve(TournamentMinDto source, Tournament destination, TournamentStatusEnum destMember, ResolutionContext context)
	{
		string statusString = source.Status;
		if (!string.IsNullOrEmpty(statusString))
		{
			statusString = char.ToUpper(statusString[0]) + statusString.Substring(1).ToLower();

			if (Enum.TryParse<TournamentStatusEnum>(statusString, true, out TournamentStatusEnum statusResult))
			{
				return statusResult;
			}
		}

		return TournamentStatusEnum.Cancelled;
	}
}

public class StatusStageResolver : IValueResolver<StageDto, Stage, TournamentStatusEnum>
{
	public TournamentStatusEnum Resolve(StageDto source, Stage destination, TournamentStatusEnum destMember, ResolutionContext context)
	{
		string statusString = source.Status;
		if (!string.IsNullOrEmpty(statusString))
		{
			statusString = char.ToUpper(statusString[0]) + statusString.Substring(1).ToLower();

			if (Enum.TryParse<TournamentStatusEnum>(statusString, true, out TournamentStatusEnum statusResult))
			{
				return statusResult;
			}
		}

		return TournamentStatusEnum.Cancelled;
	}
}