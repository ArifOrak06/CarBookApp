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
        private readonly IRepository<Car> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOneCarCommandHandler(IRepository<Car> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateOneCarCommandResult> Handle(CreateOneCarCommand createOneCarCommand)
        {
            if (createOneCarCommand == null)
                throw new CarObjectNullBadRequestException();
            var newCar = _mapper.Map<Car>(createOneCarCommand);
            await _repository.CreateAsync(newCar);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOneCarCommandResult>(newCar);
        }
    }
}
