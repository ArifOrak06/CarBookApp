using Application.Features.CQRS.Queries.CategoryQueries;
using Application.Features.CQRS.Results.CategoryResults;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, GetOneCategoryByIdQueryResult>().ReverseMap();
            CreateMap<Category, CreateOneCategoryCommandResult>().ReverseMap();
            CreateMap<Category, UpdateOneCategoryCommandResult>().ReverseMap();
        }
    }
}
