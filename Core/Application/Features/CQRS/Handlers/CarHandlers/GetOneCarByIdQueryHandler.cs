using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForCar;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetOneCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IMapper _mapper;

        public GetOneCarByIdQueryHandler(IRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public GetOneCarByIdQueryResult Handle(GetOneCarByIdQuery getOneCarByIdQuery)
        {
            var currentEntity = _repository.GetByFilter(x => x.Id.Equals(getOneCarByIdQuery.Id), false).SingleOrDefault();
            if (currentEntity == null)
                throw new CarNotFoundException(getOneCarByIdQuery.Id);
            return _mapper.Map<GetOneCarByIdQueryResult>(currentEntity);    

        }
    }
}
