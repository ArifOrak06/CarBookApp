using Application.Features.CQRS.Results.AboutResults;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.AutoMapper
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<About,GetOneAboutByIdQueryResult>().ReverseMap();
            CreateMap<About,GetAllAboutsQueryResult>().ReverseMap();
            CreateMap<About,CreateOneAboutCommandResult>().ReverseMap();
            CreateMap<About, UpdateOneAboutCommandResult>().ReverseMap();
        }
    }
}
