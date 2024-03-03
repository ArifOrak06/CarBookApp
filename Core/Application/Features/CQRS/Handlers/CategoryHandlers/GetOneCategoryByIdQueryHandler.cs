using Application.Features.CQRS.Queries.CategoryQueries;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForCategory;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetOneCategoryByIdQueryHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneCategoryByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public GetOneCategoryByIdQueryResult Handle(GetOneCategoryByIdQuery getOneCategoryByIdQuery)
        {
            var result = _repositoryManager.CategoryRepository.GetByFilter(x => x.IsActive && !x.IsDeleted && x.Id.Equals(getOneCategoryByIdQuery.Id), false).SingleOrDefault();
            if (result is null)
                throw new CategoryNotFoundException(getOneCategoryByIdQuery.Id);
            return _mapper.Map<GetOneCategoryByIdQueryResult>(result);
        }
    }
}
