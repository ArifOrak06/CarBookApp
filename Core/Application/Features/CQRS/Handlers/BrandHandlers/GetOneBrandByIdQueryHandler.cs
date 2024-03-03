using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForBrand;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetOneBrandByIdQueryHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneBrandByIdQueryHandler(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public GetOneBrandByIdQueryResult Handle(GetOneBrandByIdQuery getOneBrandByIdQuery)
        {
            var currentEntity = _repositoryManager.BrandRepository.GetByFilter(x => x.Id.Equals(getOneBrandByIdQuery.Id), false).SingleOrDefault();
            if (currentEntity == null)
                throw new BrandNotFoundException(getOneBrandByIdQuery.Id);
            return _mapper.Map<GetOneBrandByIdQueryResult>(currentEntity);
        }
    }
}
