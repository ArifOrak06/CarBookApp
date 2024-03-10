using Application.Features.CQRS.Queries.FooterAddressQueries;
using Application.Features.CQRS.Results.FooterAddressResults;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class GetAllFooterAddressesQueryHandler : IRequestHandler<GetAllFooterAddressQuery, List<GetAllFooterAddressesQueryResult>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllFooterAddressesQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllFooterAddressesQueryResult>> Handle(GetAllFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repositoryManager.FooterAdressRepository.GetAllAsync(false);
            if (entities == null)
                throw new Exception("Sistemde kayıtlı footer adres varlığı olmaması nedeniyle listeleme başarısız.");
            return _mapper.Map<List<GetAllFooterAddressesQueryResult>>(entities);

            
        }
    }
}
