using Application.Features.CQRS.Commands;
using Application.Features.CQRS.Commands.AboutCommands;
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
            CreateMap<About,CreateOneAboutCommand>().ReverseMap();
            CreateMap<About, UpdateOneAboutCommand>().ReverseMap();
            CreateMap<About, UpdateOneAboutCommandResult>().ReverseMap();
        }
    }
}
