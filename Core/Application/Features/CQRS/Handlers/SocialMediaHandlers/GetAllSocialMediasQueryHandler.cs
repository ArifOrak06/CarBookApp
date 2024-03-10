using Application.Features.CQRS.Queries.SocialMediaQueries;
using Application.Features.CQRS.Results.SocialMediaResults;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class GetAllSocialMediasQueryHandler : IRequestHandler<GetAllSocialMediasQuery, List<GetAllSocialMediasQueryResult>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllSocialMediasQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllSocialMediasQueryResult>> Handle(GetAllSocialMediasQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repositoryManager.SocialMediaRepository.GetAllAsync(false);
            if (entities.Any())
                throw new Exception("Sistemde kayıtlı social media varlığı bulunamaması nedeniyle listeleme başarısız.");
            return _mapper.Map<List<GetAllSocialMediasQueryResult>>(entities);
           
        }
    }
}
