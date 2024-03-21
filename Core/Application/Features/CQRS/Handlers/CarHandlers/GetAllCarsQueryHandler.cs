using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery,List<GetAllCarsQueryResult>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllCarsQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {

            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<List<GetAllCarsQueryResult>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var results = await _repositoryManager.CarRepository.GetAllAsync(false);
            if (results is null)
                throw new Exception("Sistemde kayıtlı Car valrığı bulunmaması nedeniyle listeleme işlemi başarısız.!");

            return _mapper.Map<List<GetAllCarsQueryResult>>(results);
        }
    }
}
