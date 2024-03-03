using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using AutoMapper;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetAllCarsWithBrandsQueryHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllCarsWithBrandsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<List<GetOneCarByIdWithBrandQueryResult>> Handle()
        {
            var entities = await _repositoryManager.CarRepository.GetAllActivesAndNonDeletedCarsWithBrandAsync(false);
            if (!entities.Any())
                throw new Exception("Database'de kayıtlı bir araç bulunmaması nedeniyle listeleme başarısız olarak gerçekleşti.!");


            List<GetOneCarByIdWithBrandQueryResult>? newResultList =  entities.Select(x => new GetOneCarByIdWithBrandQueryResult
            {
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                BrandName = x.Brand.Name,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Id = x.Id,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission,

            }).ToList();
            return newResultList;
            //var newCarWithBrands = _mapper.Map<List<GetOneCarByIdWithBrandQueryResult>>(entities);


        }
    }
}
