using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForCar;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetOneCarByIdQueryHandler : IRequestHandler<GetOneCarByIdQuery,GetOneCarByIdQueryResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneCarByIdQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {

            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<GetOneCarByIdQueryResult> Handle(GetOneCarByIdQuery request, CancellationToken cancellationToken)
        {
            var currentEntity = _repositoryManager.CarRepository.GetByFilter(x => x.Id.Equals(request.Id), false).SingleOrDefault();
            if (currentEntity == null)
                throw new CarNotFoundException(request.Id);
            return _mapper.Map<GetOneCarByIdQueryResult>(currentEntity);
        }
    }
}
