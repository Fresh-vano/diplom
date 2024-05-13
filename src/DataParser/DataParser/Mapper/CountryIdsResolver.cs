using AutoMapper;
using DataParser.Data;
using DataParser.DTOs;
using DataParser.Models;

public class CountryIdsResolver : IValueResolver<TournamentFullDto, Tournament, Country>
{
	private readonly ApplicationDbContext _context;

	public CountryIdsResolver(ApplicationDbContext context)
	{
		_context = context;
	}

	public Country? Resolve(TournamentFullDto source, Tournament destination, Country destMember, ResolutionContext context)
	{
		if (source.Country == null)
			return null;

		return _context.Countries.Where(t => t.Id == source.Country).SingleOrDefault();
	}
}
