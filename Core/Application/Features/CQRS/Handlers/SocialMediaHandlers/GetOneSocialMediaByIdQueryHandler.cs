using Application.Features.CQRS.Queries.SocialMediaQueries;
using Application.Features.CQRS.Results.SocialMediaResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForSocialMedia;
using MediatR;

namespace Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class GetOneSocialMediaByIdQueryHandler : IRequestHandler<GetOneSocialMediaByIdQuery, GetOneSocialMediaByIdQueryResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneSocialMediaByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<GetOneSocialMediaByIdQueryResult> Handle(GetOneSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _repositoryManager.SocialMediaRepository.GetByFilter(x => x.Id.Equals(request.Id), false);
            if (entity == null)
                throw new SocialMediaNotFoundException(request.Id);
            return _mapper.Map<GetOneSocialMediaByIdQueryResult>(entity);
            
        }
    }
}
