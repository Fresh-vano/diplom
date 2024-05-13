using AutoMapper;
using DataParser.DTOs;
using DataParser.Enums;
using DataParser.Models;

namespace DataParser.Mapper
{
	public class ParsedStatusResolver : IValueResolver<MatchMinDto, Match, ParsedStatusEnum>
	{
		public ParsedStatusEnum Resolve(MatchMinDto source, Match destination, ParsedStatusEnum destMember, ResolutionContext context)
		{
			string statusString = source.Status;
			if (!string.IsNullOrEmpty(statusString))
			{
				statusString = char.ToUpper(statusString[0]) + statusString.Substring(1).ToLower();

				if (Enum.TryParse<ParsedStatusEnum>(statusString, true, out ParsedStatusEnum statusResult))
				{
					return statusResult;
				}
			}

			return ParsedStatusEnum.Error;
		}
	}
}
