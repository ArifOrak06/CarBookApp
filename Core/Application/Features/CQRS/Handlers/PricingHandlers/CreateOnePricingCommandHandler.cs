using Application.Features.CQRS.Commands.PricingCommands;
using Application.Features.CQRS.Results.PricingResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForPricing;
using MediatR;

namespace Application.Features.CQRS.Handlers.PricingHandlers
{
    public class CreateOnePricingCommandHandler : IRequestHandler<CreateOnePricingCommand, CreateOnePricingCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOnePricingCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateOnePricingCommandResult> Handle(CreateOnePricingCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new PricingObjectNullBadRequestException();
            var newPricing =  _mapper.Map<Pricing>(request);
            newPricing.IsActive = true;
            newPricing.IsDeleted = false;
            newPricing.CreatedDate = DateTime.UtcNow;

            await _repositoryManager.PricingRepository.CreateAsync(newPricing);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOnePricingCommandResult>(newPricing);
          
        }
    }
}
