using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForCar;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateOneCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOneCarCommandHandler(IRepository<Car> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOneCarCommandResult> Handle(UpdateOneCarCommand updateOneCarCommand)
        {
            if (updateOneCarCommand == null)
                throw new CarObjectNullBadRequestException();
            var unchangedEntity = _repository.GetByFilter(x => x.Id.Equals(updateOneCarCommand.Id), true).SingleOrDefault();
            if (unchangedEntity == null)
                throw new CarNotFoundException(updateOneCarCommand.Id);

            unchangedEntity.Transmission = updateOneCarCommand.Transmission;
            unchangedEntity.Luggage = updateOneCarCommand.Luggage;
            unchangedEntity.Fuel = updateOneCarCommand.Fuel;
            unchangedEntity.BrandId = updateOneCarCommand.BrandId;
            unchangedEntity.BigImageUrl = updateOneCarCommand.BigImageUrl;
            unchangedEntity.CoverImageUrl = updateOneCarCommand.CoverImageUrl;
            unchangedEntity.Km = updateOneCarCommand.Km;
            unchangedEntity.Seat = updateOneCarCommand.Seat;
            unchangedEntity.Model = updateOneCarCommand.Model;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneCarCommandResult>(unchangedEntity); 
        }
    }
}
