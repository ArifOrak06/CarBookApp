using Application.Features.CQRS.Results.BannerResults;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.AutoMapper
{
    public class BannerProfile : Profile
    {
        public BannerProfile()
        {
            CreateMap<Banner, GetOneBannerByIdQueryResult>().ReverseMap();
            CreateMap<Banner, GetAllBannersQueryResult>().ReverseMap();
            CreateMap<Banner, CreateOneBannerCommandResult>().ReverseMap();
            CreateMap<Banner, UpdateOneBannerCommandResult>().ReverseMap();

        }
    }
}
