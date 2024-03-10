﻿using Application.Features.CQRS.Commands.FeatureCommands;
using Application.Features.CQRS.Results.FeatureResults;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.AutoMapper
{
    public class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, GetAllFeaturesQueryResult>().ReverseMap();
            CreateMap<Feature, GetOneFeatureByIdQueryResult>().ReverseMap();
            CreateMap<Feature, GetOneFeatureByIdWithCarFeaturesQueryResult>().ReverseMap();
            CreateMap<Feature, CreateOneFeatureCommand>().ReverseMap();
            CreateMap<Feature, UpdateOneFeatureCommand>().ReverseMap();
            CreateMap<Feature, UpdateOneFeatureCommandResult>().ReverseMap();
            CreateMap<Feature, CreateOneFeatureCommandResult>().ReverseMap();
        }
    }
}
