using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForCar;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetOneCarByIdWithBrandQueryHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneCarByIdWithBrandQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<GetOneCarByIdWithBrandQueryResult> Handle(GetOneCarByIdQuery getOneCarByIdQuery)
        {
            var currentEntity = await _repositoryManager.CarRepository.GetOneCarActiveAndNonDeletedByIdWithBrandAsync(getOneCarByIdQuery.Id, false);
            if (currentEntity == null)
                throw new CarNotFoundException(getOneCarByIdQuery.Id);
            //currentEntity.Brand = await _repositoryManager.BrandRepository.GetOneActiveAndNonDeletedBrandByIdWithCarsAsync(currentEntity.BrandId,false);
            var newCarWithBrandResult = _mapper.Map<GetOneCarByIdWithBrandQueryResult>(currentEntity);
            newCarWithBrandResult.BrandName = currentEntity.Brand.Name;
            return newCarWithBrandResult;

        }
    }
}
