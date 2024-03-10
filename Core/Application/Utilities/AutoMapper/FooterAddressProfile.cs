using Application.Features.CQRS.Commands.FooterAddressCommands;
using Application.Features.CQRS.Results.FooterAddressResults;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.AutoMapper
{
    public class FooterAddressProfile : Profile
    {
        public FooterAddressProfile()
        {
            CreateMap<FooterAddress, GetOneFooterAddressByIdQueryResult>().ReverseMap();
            CreateMap<FooterAddress, GetAllFooterAddressesQueryResult>().ReverseMap();
            CreateMap<FooterAddress, CreateOneFooterAddressCommand>().ReverseMap();
            CreateMap<FooterAddress, CreateOneFooterAddressCommandResult>().ReverseMap();
            CreateMap<FooterAddress, UpdateOneFooterAddressCommand>().ReverseMap();
            CreateMap<FooterAddress, UpdateOneFooterAddressCommandResult>().ReverseMap();
        }
    }
}
