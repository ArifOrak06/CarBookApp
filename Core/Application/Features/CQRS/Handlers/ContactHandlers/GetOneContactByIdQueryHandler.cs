using Application.Features.CQRS.Queries.ContactQueries;
using Application.Features.CQRS.Results.ContactResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForContact;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetOneContactByIdQueryHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneContactByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public GetOneContactByIdQueryResult Handle(GetOneContactByIdQuery getOneContactByIdQuery)
        {
            var currentEntity = _repositoryManager.ContactRepository.GetByFilter(x => x.Id.Equals(getOneContactByIdQuery.Id), false).SingleOrDefault();
            if (currentEntity == null)
                throw new ContactNotFoundException(getOneContactByIdQuery.Id);
            return _mapper.Map<GetOneContactByIdQueryResult>(currentEntity);
        }
    }
}
