using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.CQRS.Results.AboutResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetOneAboutByIdQueryHandler : IRequestHandler<GetOneAboutByIdQuery,GetOneAboutByIdQueryResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneAboutByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

      

        public async Task<GetOneAboutByIdQueryResult> Handle(GetOneAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var newAbout = _repositoryManager.AboutRepository.GetByFilter(x => x.Id == request.Id, false).SingleOrDefault();
            if (newAbout == null)
                throw new AboutNotFoundException(request.Id);

            return _mapper.Map<GetOneAboutByIdQueryResult>(newAbout);
        }
    }
}
