using AutoMapper;
using Cinecrate.Shared.Entities;
using Cinecrate.Shared.Models;

namespace Cinecrate.Server.Profiles
{
    public class MovieTagProfile : Profile
    {
        public MovieTagProfile()
        {
            CreateMap<MovieTag, MovieTagDto>().ReverseMap();
            //CreateMap<MovieTagDto, MovieTag>();
        }
    }
}
