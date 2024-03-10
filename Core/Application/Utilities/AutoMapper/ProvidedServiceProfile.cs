using Application.Features.CQRS.Commands.ProvidedServiceCommands;
using Application.Features.CQRS.Results.ProvidedServiceResults;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.AutoMapper
{
    public class ProvidedServiceProfile : Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedService, CreateOneProvidedServiceCommand>().ReverseMap();
            CreateMap<ProvidedService,CreateOneProvidedServiceCommandResult>().ReverseMap();
            CreateMap<ProvidedService,UpdateOneProvidedServiceCommand>().ReverseMap();
            CreateMap<ProvidedService,UpdateOneProvidedServiceCommandResult>().ReverseMap();
            CreateMap<ProvidedService,GetOneProvidedServiceByIdQueryResult>().ReverseMap();
            CreateMap<ProvidedService,GetAllProvidedServicesQueryResult>().ReverseMap();
        }
    }
}
