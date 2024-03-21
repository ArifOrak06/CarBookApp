using Application.Features.CQRS.Queries.CategoryQueries;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery,(List<GetAllCategoriesQueryResult> getAllCategoriesQueryResult, MetaData metaData)>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

      
        public async Task<(List<GetAllCategoriesQueryResult> getAllCategoriesQueryResult, MetaData metaData)> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repositoryManager.CategoryRepository.GetAllActivesAndNonDeletedCategoriesAsync(false,request);
            if (entities == null)
                throw new Exception("Sistemde kayıtlı Category varlığı bulunmadığından listeleme işlemi gerçekleştirilemedi.");
            return (getAllCategoriesQueryResult : _mapper.Map<List<GetAllCategoriesQueryResult>>(entities), metaData: entities.MetaData);
        }
    }
}
