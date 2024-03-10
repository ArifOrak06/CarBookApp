using Application.Features.CQRS.Commands.PricingCommands;
using Application.Features.CQRS.Results.PricingResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForPricing;
using MediatR;

namespace Application.Features.CQRS.Handlers.PricingHandlers
{
    public class UpdateOnePricingCommandHandler : IRequestHandler<UpdateOnePricingCommand, UpdateOnePricingCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOnePricingCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOnePricingCommandResult> Handle(UpdateOnePricingCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new PricingObjectNullBadRequestException();
            var unchangedEntitiy = _repositoryManager.PricingRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (unchangedEntitiy == null)
                throw new PricingNotFoundException(request.Id);
            unchangedEntitiy.Name = request.Name;
            unchangedEntitiy.IsActive = request.IsActive;
            if (request.IsActive) unchangedEntitiy.IsDeleted = false; else unchangedEntitiy.IsDeleted = true;
            unchangedEntitiy.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();

            return _mapper.Map<UpdateOnePricingCommandResult>(unchangedEntitiy);
        }
    }
}
