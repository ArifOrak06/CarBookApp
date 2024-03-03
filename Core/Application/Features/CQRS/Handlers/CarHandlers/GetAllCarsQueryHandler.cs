using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetAllCarsQueryHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllCarsQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {

            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<List<GetAllCarsQueryResult>> Handle()
        {
            var results = await _repositoryManager.CarRepository.GetAllAsync(false);
            if (results is null)
                throw new Exception("Sistemde kayıtlı Car valrığı bulunmaması nedeniyle listeleme işlemi başarısız.!");

            return _mapper.Map<List<GetAllCarsQueryResult>>(results);

        }
    }
}
