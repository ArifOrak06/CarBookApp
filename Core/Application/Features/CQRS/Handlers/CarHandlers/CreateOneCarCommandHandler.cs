using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateOneCarCommandHandler : IRequestHandler<CreateOneCarCommand,CreateOneCarCommandResult>
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

      
        public async Task<CreateOneCarCommandResult> Handle(CreateOneCarCommand request, CancellationToken cancellationToken)
        {
            var newCar = _mapper.Map<Car>(request);
            newCar.CreatedDate = DateTime.UtcNow;
            newCar.IsActive = true;
            newCar.IsDeleted = false;
            await _repositoryManger.CarRepository.CreateAsync(newCar);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOneCarCommandResult>(newCar);
        }
    }
}
