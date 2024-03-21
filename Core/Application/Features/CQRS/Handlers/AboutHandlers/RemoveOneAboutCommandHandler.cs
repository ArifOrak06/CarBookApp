using Application.Features.CQRS.Commands.AboutCommands;
using Application.Features.CQRS.Results.AboutResults;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveOneAboutCommandHandler : IRequestHandler<RemoveOneAboutCommand,RemoveOneAboutCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOneAboutCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }
       

        public async Task<RemoveOneAboutCommandResult> Handle(RemoveOneAboutCommand request, CancellationToken cancellationToken)
        {
            var currentAbout = _repositoryManager.AboutRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (currentAbout is null)
                throw new AboutNotFoundException(request.Id);

            _repositoryManager.AboutRepository.Delete(currentAbout);
            await _unitOfWork.CommitAsync();
            return new RemoveOneAboutCommandResult(request.Id);
        }
    }
}
