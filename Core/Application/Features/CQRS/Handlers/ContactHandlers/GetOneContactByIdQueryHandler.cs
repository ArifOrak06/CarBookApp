using Application.Features.CQRS.Queries.ContactQueries;
using Application.Features.CQRS.Results.ContactResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForContact;
using MediatR;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetOneContactByIdQueryHandler : IRequestHandler<GetOneContactByIdQuery,GetOneContactByIdQueryResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneContactByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<GetOneContactByIdQueryResult> Handle(GetOneContactByIdQuery request, CancellationToken cancellationToken)
        {
            var currentEntity = _repositoryManager.ContactRepository.GetByFilter(x => x.Id.Equals(request.Id), false).SingleOrDefault();
            if (currentEntity == null)
                throw new ContactNotFoundException(request.Id);
            return _mapper.Map<GetOneContactByIdQueryResult>(currentEntity);
        }
    }
}
