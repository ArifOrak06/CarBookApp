﻿using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetAllBrandsQueryHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllBrandsQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {

            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllBrandsQueryResult>> Handle()
        {
            var result = await _repositoryManager.BrandRepository.GetAllAsync(false);
            if (result == null)
                throw new Exception("Database'de kayıtlı brand bulunmaması nedeniyle listeleme başarısız.");
            return  _mapper.Map<List<GetAllBrandsQueryResult>>(result);

        }
        
    }
}
