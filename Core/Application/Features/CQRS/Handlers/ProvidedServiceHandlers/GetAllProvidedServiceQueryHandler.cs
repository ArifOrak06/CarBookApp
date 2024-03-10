using Application.Features.CQRS.Queries.ProvidedServiceQueries;
using Application.Features.CQRS.Results.ProvidedServiceResults;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CQRS.Handlers.ProvidedServiceHandlers
{
    public class GetAllProvidedServiceQueryHandler : IRequestHandler<GetAllProvidedServicesQuery, List<GetAllProvidedServicesQueryResult>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllProvidedServiceQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllProvidedServicesQueryResult>> Handle(GetAllProvidedServicesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repositoryManager.ProvidedServiceRepository.GetAllAsync(false);
            if (entities == null)
                throw new Exception("Sistemde kayıtlı provided Service varlığı olmaması nedeniyle listeleme başarısız.");
            return _mapper.Map<List<GetAllProvidedServicesQueryResult>>(entities);

            
        }
    }
}
