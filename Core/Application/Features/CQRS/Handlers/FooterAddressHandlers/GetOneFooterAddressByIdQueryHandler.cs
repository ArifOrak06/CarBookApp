using Application.Features.CQRS.Queries.FooterAddressQueries;
using Application.Features.CQRS.Results.FooterAddressResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForFooterAddress;
using MediatR;

namespace Application.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class GetOneFooterAddressByIdQueryHandler : IRequestHandler<GetOneFooterAddressByIdQuery, GetOneFooterAddressByIdQueryResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneFooterAddressByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<GetOneFooterAddressByIdQueryResult> Handle(GetOneFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var entitiy = _repositoryManager.FooterAdressRepository.GetByFilter(x => x.Id.Equals(request.Id), false).SingleOrDefault();
            if (entitiy == null)
                throw new FooterAddressNotFoundException(request.Id);
            return _mapper.Map<GetOneFooterAddressByIdQueryResult>(entitiy);


        }
    }
}
