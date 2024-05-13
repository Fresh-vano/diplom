using AutoMapper;
using DataParser.DTOs;
using DataParser.Enums;
using DataParser.Models;
using System;

public class TierResolver : IValueResolver<TournamentMinDto, Tournament, TierEnum>
{
	public TierEnum Resolve(TournamentMinDto source, Tournament destination, TierEnum destMember, ResolutionContext context)
	{
		if (!string.IsNullOrEmpty(source.Tier))
		{
			string tierString = source.Tier.ToUpper(); 
			if (Enum.TryParse<TierEnum>(tierString, out TierEnum tierResult))
			{
				return tierResult;
			}
		}

		return TierEnum.C;
	}
}
