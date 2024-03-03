using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Commands.ContactCommands;
using Application.Features.CQRS.Results.ContactResults;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.AutoMapper
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact,GetOneContactByIdQueryResult>().ReverseMap();
            CreateMap<Contact,GetAllContactsQueryResult>().ReverseMap();
            CreateMap<Contact,CreateOneContactCommand>().ReverseMap();
            CreateMap<Contact,CreateOneContactCommandResult>().ReverseMap();
            CreateMap<Contact,UpdateOneContactCommand>().ReverseMap();
            CreateMap<Contact, UpdateOneContactCommandResult>().ReverseMap();
        }
    }
}
