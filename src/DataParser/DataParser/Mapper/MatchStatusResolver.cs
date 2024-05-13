using AutoMapper;
using DataParser.DTOs;
using DataParser.Enums;
using DataParser.Models;

namespace DataParser.Mapper
{
	public class MatchStatusResolver : IValueResolver<MatchMinDto, Match, MatchStatusEnum>
	{
		public MatchStatusEnum Resolve(MatchMinDto source, Match destination, MatchStatusEnum destMember, ResolutionContext context)
		{
			string statusString = source.Status;
			if (!string.IsNullOrEmpty(statusString))
			{
				statusString = char.ToUpper(statusString[0]) + statusString.Substring(1).ToLower();

				if (Enum.TryParse<MatchStatusEnum>(statusString, true, out MatchStatusEnum statusResult))
				{
					return statusResult;
				}
			}

			return MatchStatusEnum.Cancelled;
		}
	}
}
