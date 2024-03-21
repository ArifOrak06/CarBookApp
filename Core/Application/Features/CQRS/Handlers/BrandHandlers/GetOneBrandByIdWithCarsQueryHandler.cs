using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Results.BrandResults;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForBrand;
using MediatR;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetOneBrandByIdWithCarsQueryHandler : IRequestHandler<GetOneBrandByIdWithCarsQuery,GetOneBrandByIdWithCarsQueryResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneBrandByIdWithCarsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<GetOneBrandByIdWithCarsQueryResult> Handle(GetOneBrandByIdWithCarsQuery request, CancellationToken cancellationToken)
        {
            var currentBrand = await _repositoryManager.BrandRepository.GetOneActiveAndNonDeletedBrandByIdWithCarsAsync(request.Id, false);
            if (currentBrand is null)
                throw new BrandNotFoundException(request.Id);
            currentBrand.Cars = await _repositoryManager.CarRepository.GetAllActivesAndNonDeletedCarsByBrandIdAsync(request.Id, false);
            foreach (var car in currentBrand.Cars)
            {
                _mapper.Map<GetOneCarByIdQueryResult>(car);
            }
            return _mapper.Map<GetOneBrandByIdWithCarsQueryResult>(currentBrand);
        }
    }
}
