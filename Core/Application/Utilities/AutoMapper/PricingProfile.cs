using Application.Features.CQRS.Commands.PricingCommands;
using Application.Features.CQRS.Results.PricingResults;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.AutoMapper
{
    public class PricingProfile : Profile
    {
        public PricingProfile()
        {
            CreateMap<Pricing, CreateOnePricingCommand>().ReverseMap();
            CreateMap<Pricing, CreateOnePricingCommandResult>().ReverseMap();
            CreateMap<Pricing, UpdateOnePricingCommand>().ReverseMap();
            CreateMap<Pricing, UpdateOnePricingCommandResult>().ReverseMap();
            CreateMap<Pricing, GetOnePricingByIdQueryResult>().ReverseMap();
            CreateMap<Pricing, GetAllPricingsQueryResult>().ReverseMap();
        }
    }
}
