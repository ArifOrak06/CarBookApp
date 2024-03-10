using Application.Features.CQRS.Commands.SocialMediaCommands;
using Application.Features.CQRS.Results.SocialMediaResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForSocialMedia;
using MediatR;

namespace Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class UpdateOneSocialMediaCommandHandler : IRequestHandler<UpdateOneSocialMediaCommand, UpdateOneSocialMediaCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOneSocialMediaCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOneSocialMediaCommandResult> Handle(UpdateOneSocialMediaCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new SocialMediaObjectNullBadRequestException();
            var unchangedEntity = _repositoryManager.SocialMediaRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (unchangedEntity == null)
                throw new SocialMediaNotFoundException(request.Id);
            unchangedEntity.Url = request.Url;
            unchangedEntity.IsActive = request.IsActive;
            if (request.IsActive) unchangedEntity.IsDeleted = false; else unchangedEntity.IsDeleted = true;
            unchangedEntity.ModifiedDate = DateTime.UtcNow;
            unchangedEntity.Icon = request.Icon;
            unchangedEntity.Name = request.Name;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneSocialMediaCommandResult>(unchangedEntity);
            
        }
    }
}
