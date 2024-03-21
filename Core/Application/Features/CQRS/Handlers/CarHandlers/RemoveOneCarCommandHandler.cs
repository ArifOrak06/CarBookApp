using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Exceptions.ExceptionsForCar;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveOneCarCommandHandler : IRequestHandler<RemoveOneCarCommand,RemoveOneCarCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;


        public RemoveOneCarCommandHandler(IUnitOfWork unitOfWork, IRepositoryManager repositoryManager)
        {

            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }

        public async  Task<RemoveOneCarCommandResult> Handle(RemoveOneCarCommand request, CancellationToken cancellationToken)
        {
            var currentEntity = _repositoryManager.CarRepository.GetByFilter(x => x.Id == request.Id, true).SingleOrDefault();
            if (currentEntity == null)
                throw new CarNotFoundException(request.Id);
            _repositoryManager.CarRepository.Delete(currentEntity);
            await _unitOfWork.CommitAsync();
            return new RemoveOneCarCommandResult(request.Id);
        }
    }
}
