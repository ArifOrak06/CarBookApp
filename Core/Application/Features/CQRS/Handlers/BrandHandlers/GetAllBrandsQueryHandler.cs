using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery,(List<GetAllBrandsQueryResult> getAllBrandsQueryResult,MetaData metaData)>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllBrandsQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {

            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<(List<GetAllBrandsQueryResult> getAllBrandsQueryResult, MetaData metaData)> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repositoryManager.BrandRepository.GetAllActiveAndNonDeletedBrandsWithCarsAsync(false,request);
            if (result == null)
                throw new Exception("Database'de kayıtlı brand bulunmaması nedeniyle listeleme başarısız.");
            return (getAllBrandsQueryResult : _mapper.Map<List<GetAllBrandsQueryResult>>(result),result.MetaData);
        }
    }
}
