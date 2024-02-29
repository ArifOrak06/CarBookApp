using Application.Features.CQRS.Commands.CarCommands;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForCar;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveOneCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public RemoveOneCarCommandHandler(IRepository<Car> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
         
        }

        public async Task<int> Handle(RemoveOneCarCommand removeOneCarCommand)
        {
            var currentEntity = _repository.GetByFilter(x => x.Id == removeOneCarCommand.Id, true).SingleOrDefault();
            if (currentEntity == null) 
                throw new CarNotFoundException(removeOneCarCommand.Id);
            _repository.Delete(currentEntity);
            await _unitOfWork.CommitAsync();
            return removeOneCarCommand.Id;
        }
    }
}
