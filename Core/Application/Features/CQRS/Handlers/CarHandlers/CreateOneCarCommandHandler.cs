using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForCar;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateOneCarCommandHandler
    {
        private readonly IRepositoryManager _repositoryManger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOneCarCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IRepositoryManager repositoryManger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repositoryManger = repositoryManger;
        }

        public async Task<CreateOneCarCommandResult> Handle(CreateOneCarCommand createOneCarCommand)
        {
            if (createOneCarCommand == null)
                throw new CarObjectNullBadRequestException();
            var newCar = _mapper.Map<Car>(createOneCarCommand);
            await _repositoryManger.CarRepository.CreateAsync(newCar);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOneCarCommandResult>(newCar);
        }
    }
}
