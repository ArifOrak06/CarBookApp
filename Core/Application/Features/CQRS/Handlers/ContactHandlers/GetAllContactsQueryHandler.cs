using Application.Features.CQRS.Results.ContactResults;
using Application.Repositories;
using AutoMapper;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetAllContactsQueryHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllContactsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllContactsQueryResult>> Handle()
        {
            var entities = await _repositoryManager.ContactRepository.GetAllAsync(false);
            if (entities == null)
                throw new Exception("Sistemde kayıtlı Contact varlığı bulunmaması nedeniyle listeleme işlemi gerçekleştirilememiştir.");
            return _mapper.Map<List<GetAllContactsQueryResult>>(entities);

        }
    }
}
