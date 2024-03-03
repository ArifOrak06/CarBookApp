using Application.Features.CQRS.Results.CategoryResults;
using Application.Repositories;
using AutoMapper;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetAllCategoriesQueryHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<List<GetOneCategoryByIdQueryResult>> Handle()
        {
            var entities = await _repositoryManager.CategoryRepository.GetAllAsync(false);
            if (entities == null)
                throw new Exception("Sistemde kayıtlı Category varlığı bulunmadığından listeleme işlemi gerçekleştirilemedi.");
            return _mapper.Map<List<GetOneCategoryByIdQueryResult>>(entities);
        }
    }
}
