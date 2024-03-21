using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Results.BrandResults;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.AutoMapper
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand,GetOneBrandByIdQueryResult>().ReverseMap();
            CreateMap<Brand,GetAllBrandsQueryResult>().ReverseMap();
            CreateMap<Brand,CreateOneBrandCommand>().ReverseMap();
            CreateMap<Brand,CreateOneBrandCommandResult>().ReverseMap();
            CreateMap<Brand,UpdateOneBrandCommand>().ReverseMap();
            CreateMap<Brand,UpdateOneBrandCommandResult>().ReverseMap();
            CreateMap<Brand,GetOneBrandByIdWithCarsQueryResult>().ReverseMap();
        }
    }
}
