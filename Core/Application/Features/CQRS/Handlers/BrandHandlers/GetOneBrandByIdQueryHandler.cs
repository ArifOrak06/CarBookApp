using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForBrand;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetOneBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;

        public GetOneBrandByIdQueryHandler(IRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public GetOneBrandByIdQueryResult Handle(GetOneBrandByIdQuery getOneBrandByIdQuery)
        {
            var currentEntity = _repository.GetByFilter(x => x.Id.Equals(getOneBrandByIdQuery.Id), false).SingleOrDefault();
            if (currentEntity == null)
                throw new BrandNotFoundException(getOneBrandByIdQuery.Id);
            return _mapper.Map<GetOneBrandByIdQueryResult>(currentEntity);
        }
    }
}
