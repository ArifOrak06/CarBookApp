using Application.Features.CQRS.Queries.CategoryQueries;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForCategory;
using MediatR;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetOneCategoryByIdQueryHandler : IRequestHandler<GetOneCategoryByIdQuery,GetOneCategoryByIdQueryResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneCategoryByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

      
        public async Task<GetOneCategoryByIdQueryResult> Handle(GetOneCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _repositoryManager.CategoryRepository.GetByFilter(x => x.IsActive && !x.IsDeleted && x.Id.Equals(request.Id), false).SingleOrDefault();
            if (result is null)
                throw new CategoryNotFoundException(request.Id);
            return _mapper.Map<GetOneCategoryByIdQueryResult>(result);
        }
    }
}
