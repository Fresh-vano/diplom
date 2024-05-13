using AutoMapper;
using DataParser.Data;
using DataParser.DTOs;
using DataParser.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class TeamIdsResolver : IValueResolver<StageDto, Stage, List<Team>?>
{
	private readonly ApplicationDbContext _context;

	public TeamIdsResolver(ApplicationDbContext context)
	{
		_context = context;
	}

	public List<Team>? Resolve(StageDto source, Stage destination, List<Team>? destMember, ResolutionContext context)
	{
		var teamIds = source.Teams?.Select(t => t.Id).ToList();
		if (teamIds == null || !teamIds.Any())
			return null;

		return _context.Teams
			.Where(t => teamIds.Contains(t.Id))
			.ToList();
	}
}
