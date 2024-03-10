using Application.Features.CQRS.Commands.SocialMediaCommands;
using Application.Features.CQRS.Results.SocialMediaResults;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Exceptions.ExceptionsForSocialMedia;
using MediatR;

namespace Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class RemoveOneSocialMediaCommandHandler : IRequestHandler<RemoveOneSocialMediaCommand, RemoveOneSocialMediaCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOneSocialMediaCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveOneSocialMediaCommandResult> Handle(RemoveOneSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var deletedEntity = _repositoryManager.SocialMediaRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if(deletedEntity is null)
                throw new SocialMediaNotFoundException(request.Id);
            _repositoryManager.SocialMediaRepository.Delete(deletedEntity);
            await _unitOfWork.CommitAsync();
            return new RemoveOneSocialMediaCommandResult(request.Id);
            
        }
    }
}
