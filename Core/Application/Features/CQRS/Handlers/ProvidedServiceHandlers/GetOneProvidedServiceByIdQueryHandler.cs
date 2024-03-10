using Application.Features.CQRS.Queries.ProvidedServiceQueries;
using Application.Features.CQRS.Results.ProvidedServiceResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForProvidedService;
using MediatR;

namespace Application.Features.CQRS.Handlers.ProvidedServiceHandlers
{
    public class GetOneProvidedServiceByIdQueryHandler : IRequestHandler<GetOneProvidedServiceByIdQuery, GetOneProvidedServiceByIdQueryResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneProvidedServiceByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<GetOneProvidedServiceByIdQueryResult> Handle(GetOneProvidedServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var currentEntity = _repositoryManager.ProvidedServiceRepository.GetByFilter(x => x.Id.Equals(request.Id), false).SingleOrDefault();
            if(currentEntity == null)
                throw new ProvidedServiceNotFoundException(request.Id);
            return _mapper.Map<GetOneProvidedServiceByIdQueryResult>(currentEntity);
            
        }
    }
}
