using AutoMapper;
using Cinecrate.Shared.Entities;
using Cinecrate.Shared.Models;

namespace Cinecrate.Server.Profiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDto>().ReverseMap();
        }
    }
}
