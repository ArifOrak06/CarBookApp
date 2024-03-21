using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Results.CarResults;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.AutoMapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car,GetOneCarByIdQueryResult>().ReverseMap();
            CreateMap<Car,GetAllCarsQueryResult>().ReverseMap();
            CreateMap<Car,CreateOneCarCommand>().ReverseMap();
            CreateMap<Car,CreateOneCarCommandResult>().ReverseMap();
            CreateMap<Car,UpdateOneCarCommand>().ReverseMap();
            CreateMap<Car,UpdateOneCarCommandResult>().ReverseMap();
            CreateMap<Car,GetOneCarByIdWithBrandQueryResult>().ReverseMap();
            CreateMap<Car,GetAllCarsWithBrandsQueryResult>().ReverseMap();
        }
    }
}
