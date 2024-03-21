using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetAllCarsWithBrandsQueryHandler : IRequestHandler<GetAllCarsWithBrandsQuery,(List<GetAllCarsWithBrandsQueryResult> result,MetaData metaData)>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllCarsWithBrandsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<(List<GetAllCarsWithBrandsQueryResult> result,MetaData metaData)> Handle(GetAllCarsWithBrandsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repositoryManager.CarRepository.GetAllActivesAndNonDeletedCarsWithBrandAsync(false,request);
            if (!entities.Any()) throw new Exception("Sistemde kayıtlı bir araç bulunmaması nedeniyle listeleme başarısız olarak gerçekleşti.!");

            List<GetAllCarsWithBrandsQueryResult> carsWithBrandsResultList = new();
            foreach (var entity in entities)
            {
                var newResult = _mapper.Map<GetAllCarsWithBrandsQueryResult>(entity);
                newResult.BrandName = entity.Brand.Name;
                carsWithBrandsResultList.Add(newResult);
            }
            return (result: carsWithBrandsResultList, metaData: entities.MetaData);
        }

        
    }
}
