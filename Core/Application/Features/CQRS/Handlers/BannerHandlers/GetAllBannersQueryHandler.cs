using Application.Features.CQRS.Queries.BannerQueries;
using Application.Features.CQRS.Results.BannerResults;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetAllBannersQueryHandler : IRequestHandler<GetAllBannersQuery, List<GetAllBannersQueryResult>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllBannersQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {

            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<List<GetAllBannersQueryResult>> Handle(GetAllBannersQuery request, CancellationToken cancellationToken)
        {
            var results = await _repositoryManager.BannerRepository.GetAllAsync(false);
            if (!results.Any())
                throw new Exception("Sistemde kayıtlı banner bulunmaması nedeniyle listeleme işlemi başarısız olarak gerçekleştirildi.");

            //List<GetAllBannersQueryResult> queryResults = new();
            //foreach (var result in results)
            //{
            //    queryResults.Add(new()
            //    {
            //        Id = result.Id,
            //        Description = result.Description,
            //        Title = result.Title,
            //        VideoDescription = result.VideoDescription,
            //        VideoUrl = result.VideoUrl
            //    });
            //}
            return _mapper.Map<List<GetAllBannersQueryResult>>(results);

        }
    }
}
