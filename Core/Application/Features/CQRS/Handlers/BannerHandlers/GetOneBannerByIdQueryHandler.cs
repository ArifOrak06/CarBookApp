using Application.Features.CQRS.Queries.BannerQueries;
using Application.Features.CQRS.Results.BannerResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForBanner;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetOneBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;
        public GetOneBannerByIdQueryHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public GetOneBannerByIdQueryResult Handle(GetOneBannerByIdQuery query)
        {
            var result = _repository.GetByFilter(x => x.Id.Equals(query.Id), false).SingleOrDefault();
            if (result is null)
                throw new BannerNotFoundException(query.Id);
            //return new GetOneBannerByIdQueryResult
            //{
            //    Description = result.Description,
            //    Id = result.Id,
            //    Title = result.Title,
            //    VideoDescription = result.VideoDescription,
            //    VideoUrl = result.VideoUrl

            //};
            return _mapper.Map<GetOneBannerByIdQueryResult>(result);
        }
    }
}
