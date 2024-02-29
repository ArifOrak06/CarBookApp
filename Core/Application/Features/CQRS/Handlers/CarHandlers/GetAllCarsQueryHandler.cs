using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetAllCarsQueryHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IMapper _mapper;

        public GetAllCarsQueryHandler(IRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCarsQueryResult>> Handle()
        {
            var results = await _repository.GetAllAsync(false);
            if (results is null)
                throw new Exception("Sistemde kayıtlı Car valrığı bulunmaması nedeniyle listeleme işlemi başarısız.!");

            return _mapper.Map<List<GetAllCarsQueryResult>>(results);

        }
    }
}
