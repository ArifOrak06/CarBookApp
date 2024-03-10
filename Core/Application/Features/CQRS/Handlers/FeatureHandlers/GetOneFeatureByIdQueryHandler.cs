using Application.Features.CQRS.Queries.FeatureQueries;
using Application.Features.CQRS.Results.FeatureResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForFeature;
using MediatR;

namespace Application.Features.CQRS.Handlers.FeatureHandlers
{
    public class GetOneFeatureByIdQueryHandler : IRequestHandler<GetOneFeatureByIdQuery, GetOneFeatureByIdQueryResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneFeatureByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<GetOneFeatureByIdQueryResult> Handle(GetOneFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var currentEntity = _repositoryManager.FeatureRepository.GetByFilter(x => x.Id.Equals(request.Id), false).SingleOrDefault();
            if (currentEntity == null)
                throw new FeatureNotFoundException(request.Id);
            return _mapper.Map<GetOneFeatureByIdQueryResult>(currentEntity);
        }
    }
}
