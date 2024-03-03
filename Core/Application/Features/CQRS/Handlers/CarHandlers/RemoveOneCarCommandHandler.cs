using Application.Features.CQRS.Commands.CarCommands;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Exceptions.ExceptionsForCar;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveOneCarCommandHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;


        public RemoveOneCarCommandHandler(IUnitOfWork unitOfWork, IRepositoryManager repositoryManager)
        {

            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<int> Handle(RemoveOneCarCommand removeOneCarCommand)
        {
            var currentEntity = _repositoryManager.CarRepository.GetByFilter(x => x.Id == removeOneCarCommand.Id, true).SingleOrDefault();
            if (currentEntity == null) 
                throw new CarNotFoundException(removeOneCarCommand.Id);
            _repositoryManager.CarRepository.Delete(currentEntity);
            await _unitOfWork.CommitAsync();
            return removeOneCarCommand.Id;
        }
    }
}
