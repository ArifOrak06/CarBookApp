using Application.Features.CQRS.Commands.LocationCommands;
using Application.Features.CQRS.Results.LocationResults;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.AutoMapper
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location,CreateOneLocationCommand>().ReverseMap();
            CreateMap<Location,CreateOneLocationCommandResult>().ReverseMap();
            CreateMap<Location, UpdateOneLocationCommand>().ReverseMap();
            CreateMap<Location, UpdateOneLocationCommandResult>().ReverseMap();
            CreateMap<Location, GetOneLocationByIdQueryResult>().ReverseMap();
            CreateMap<Location, GetAllLocationsQueryResult>().ReverseMap();
        }
    }
}
