using AutoMapper;
using DataParser.DTOs;
using DataParser.Enums;
using DataParser.Models;

namespace DataParser.Mapper
{
	public class StageTypeResolver : IValueResolver<StageDto, Stage, StageTypeEnum>
	{
		public StageTypeEnum Resolve(StageDto source, Stage destination, StageTypeEnum destMember, ResolutionContext context)
		{
			string statusString = source.Status;
			if (!string.IsNullOrEmpty(statusString))
			{
				if (Enum.TryParse<StageTypeEnum>(statusString, true, out StageTypeEnum statusResult))
				{
					return statusResult;
				}
			}

			return StageTypeEnum.Null;
		}
	}
}
