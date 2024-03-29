﻿using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.CQRS.Results.AboutResults;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAllAboutsQueryHandler : IRequestHandler<GetAllAboutsQuery,List<GetAllAboutsQueryResult>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllAboutsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllAboutsQueryResult>> Handle(GetAllAboutsQuery request, CancellationToken cancellationToken)
        {
            var results = await _repositoryManager.AboutRepository.GetAllAsync(false);
            if (!results.Any())
                throw new Exception("Listeleme yapılacak About metni bulunmamaktadır.");
            return _mapper.Map<List<GetAllAboutsQueryResult>>(results);
        }
    }
}
