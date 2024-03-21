using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForCar;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetOneCarByIdWithBrandQueryHandler : IRequestHandler<GetOneCarByIdWithBrandQuery,GetOneCarByIdWithBrandQueryResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneCarByIdWithBrandQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<GetOneCarByIdWithBrandQueryResult> Handle(GetOneCarByIdWithBrandQuery request, CancellationToken cancellationToken)
        {
            var currentEntity = await _repositoryManager.CarRepository.GetOneCarActiveAndNonDeletedByIdWithBrandAsync(request.Id, false);
            if (currentEntity == null)
                throw new CarNotFoundException(request.Id);
            //currentEntity.Brand = await _repositoryManager.BrandRepository.GetOneActiveAndNonDeletedBrandByIdWithCarsAsync(currentEntity.BrandId,false);
            var newCarWithBrandResult = _mapper.Map<GetOneCarByIdWithBrandQueryResult>(currentEntity);
            newCarWithBrandResult.BrandName = currentEntity.Brand.Name;
            return newCarWithBrandResult;
        }
    }
}
