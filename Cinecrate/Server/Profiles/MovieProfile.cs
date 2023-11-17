using AutoMapper;
using Cinecrate.Shared.Entities;
using Cinecrate.Shared.Models;

namespace Cinecrate.Server.Profiles
{
    public class MovieProfile : Profile
	{
		public MovieProfile()
		{
			CreateMap<Movie, MovieDto>();
			CreateMap<Movie, MovieWithTagsDto>()
				.ForMember(movieDto => movieDto.Tags, memberOptions: opt => opt.MapFrom(
					movie => movie.MovieTags.Select(
						movieTag => new TagDto
						{
							Name = movieTag.Tag.Name,
							TagId = movieTag.Tag.TagId
						}).ToList()));
			CreateMap<MovieWithTagsDto, Movie>();
			CreateMap<MovieTag, MovieTagDto>();
			CreateMap<Tag, TagDto>();
			CreateMap<TagDto, Tag>();
		}
	}
}
