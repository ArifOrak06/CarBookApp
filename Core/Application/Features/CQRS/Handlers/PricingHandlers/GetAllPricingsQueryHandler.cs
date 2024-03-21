using Application.Features.CQRS.Queries.PricingQueries;
using Application.Features.CQRS.Results.AboutResults;
using Application.Features.CQRS.Results.PricingResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Handlers.PricingHandlers
{
    public class GetAllPricingsQueryHandler : IRequestHandler<GetAllPricingsQuery,(List<GetAllPricingsQueryResult> getAllPricingsQueryResult,MetaData metaData)>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllPricingsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<(List<GetAllPricingsQueryResult> getAllPricingsQueryResult, MetaData metaData)> Handle(GetAllPricingsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repositoryManager.PricingRepository.GetAllActivesAndNonDeletedPricingsAsync(false,request);
            if (entities.Any())
                throw new Exception("Sistemde kayıtlı fiyatlandırma bilgisi bulunmaması nedeni ile listeleme başarısız");
            return (getAllPricingsQueryResult : _mapper.Map<List<GetAllPricingsQueryResult>>(entities),entities.MetaData);
        }
    }
}
