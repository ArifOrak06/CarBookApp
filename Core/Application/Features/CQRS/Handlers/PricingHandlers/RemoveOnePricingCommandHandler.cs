using Application.Features.CQRS.Commands.PricingCommands;
using Application.Features.CQRS.Results.PricingResults;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Exceptions.ExceptionsForPricing;
using MediatR;

namespace Application.Features.CQRS.Handlers.PricingHandlers
{
    public class RemoveOnePricingCommandHandler : IRequestHandler<RemoveOnePricingCommand, RemoveOnePricingCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOnePricingCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveOnePricingCommandResult> Handle(RemoveOnePricingCommand request, CancellationToken cancellationToken)
        {
            var currentEntity = _repositoryManager.PricingRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if(currentEntity is null)
                throw new PricingNotFoundException(request.Id);
            _repositoryManager.PricingRepository.Delete(currentEntity);
            await _unitOfWork.CommitAsync();
            return new RemoveOnePricingCommandResult(request.Id);
           
        }
    }
}
