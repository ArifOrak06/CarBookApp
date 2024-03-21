using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForCar;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateOneCarCommandHandler : IRequestHandler<UpdateOneCarCommand,UpdateOneCarCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOneCarCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IRepositoryManager repositoryManager)
        {

            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOneCarCommandResult> Handle(UpdateOneCarCommand request, CancellationToken cancellationToken)
        {
            var unchangedEntity = _repositoryManager.CarRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (unchangedEntity == null)
                throw new CarNotFoundException(request.Id);

            unchangedEntity.Transmission = request.Transmission;
            unchangedEntity.Luggage = request.Luggage;
            unchangedEntity.Fuel = request.Fuel;
            unchangedEntity.BrandId = request.BrandId;
            unchangedEntity.BigImageUrl = request.BigImageUrl;
            unchangedEntity.CoverImageUrl = request.CoverImageUrl;
            unchangedEntity.Km = request.Km;
            unchangedEntity.Seat = request.Seat;
            unchangedEntity.Model = request.Model;
            unchangedEntity.IsActive = request.IsActive;
            unchangedEntity.ModifiedDate = DateTime.UtcNow;
            if (request.IsActive) unchangedEntity.IsDeleted = false; else unchangedEntity.IsDeleted = true;

            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneCarCommandResult>(unchangedEntity);
        }
    }
}
