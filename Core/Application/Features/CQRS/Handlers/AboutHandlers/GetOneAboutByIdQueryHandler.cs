using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.CQRS.Results.AboutResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetOneAboutByIdQueryHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneAboutByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public GetOneAboutByIdQueryResult Handle(GetOneAboutByIdQuery getOneAboutByIdQuery)
        {
            var newAbout = _repositoryManager.AboutRepository.GetByFilter(x => x.Id == getOneAboutByIdQuery.Id, false).SingleOrDefault();
            if (newAbout == null)
                throw new AboutNotFoundException(getOneAboutByIdQuery.Id);

            return _mapper.Map<GetOneAboutByIdQueryResult>(newAbout);
        }
    }
}
