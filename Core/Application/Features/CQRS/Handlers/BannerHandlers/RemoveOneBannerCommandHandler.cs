using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Results.BannerResults;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Exceptions.ExceptionsForBanner;
using MediatR;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveOneBannerCommandHandler : IRequestHandler<RemoveOneBannerCommand,RemoveOneBannerCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOneBannerCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveOneBannerCommandResult> Handle(RemoveOneBannerCommand request, CancellationToken cancellationToken)
        {
            var currentEntity = _repositoryManager.BannerRepository.GetByFilter(x => x.Id == request.Id, true).SingleOrDefault();
            if (currentEntity != null)
                throw new BannerNotFoundException(request.Id);
            _repositoryManager.BannerRepository.Delete(currentEntity);
            await _unitOfWork.CommitAsync();
            return new RemoveOneBannerCommandResult(request.Id);
        }
    }
}
