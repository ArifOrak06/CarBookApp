using Application.Features.CQRS.Queries.PricingQueries;
using Application.Features.CQRS.Results.PricingResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForPricing;
using MediatR;

namespace Application.Features.CQRS.Handlers.PricingHandlers
{
    public class GetOnePricingByIdQueryHandler : IRequestHandler<GetOnePricingByIdQuery, GetOnePricingByIdQueryResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOnePricingByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<GetOnePricingByIdQueryResult> Handle(GetOnePricingByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _repositoryManager.PricingRepository.GetByFilter(x => x.Id.Equals(request.Id), false).SingleOrDefault();
            if (entity == null)
                throw new PricingNotFoundException(request.Id);
            return _mapper.Map<GetOnePricingByIdQueryResult>(entity);
            
        }
    }
}
