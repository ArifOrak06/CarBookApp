using Application.Features.CQRS.Commands.SocialMediaCommands;
using Application.Features.CQRS.Results.SocialMediaResults;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.AutoMapper
{
    public class SocialMediaProfile : Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<SocialMedia, CreateOneSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, CreateOneSocialMediaCommandResult>().ReverseMap();
            CreateMap<SocialMedia, UpdateOneSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, UpdateOneSocialMediaCommandResult>().ReverseMap();
            CreateMap<SocialMedia, GetOneSocialMediaByIdQueryResult>().ReverseMap();
            CreateMap<SocialMedia, GetAllSocialMediasQueryResult>().ReverseMap();
        }
    }
}
