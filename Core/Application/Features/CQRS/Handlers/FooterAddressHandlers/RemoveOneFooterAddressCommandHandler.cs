using Application.Features.CQRS.Commands.FooterAddressCommands;
using Application.Features.CQRS.Results.FooterAddressResults;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Exceptions.ExceptionsForFooterAddress;
using MediatR;

namespace Application.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class RemoveOneFooterAddressCommandHandler : IRequestHandler<RemoveOneFooterAddressCommand, RemoveOneFooterAddressCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOneFooterAddressCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveOneFooterAddressCommandResult> Handle(RemoveOneFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = _repositoryManager.FooterAdressRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if(entity == null) 
                throw new FooterAddressNotFoundException(request.Id);
            _repositoryManager.FooterAdressRepository.Delete(entity);
            await _unitOfWork.CommitAsync();
            return new RemoveOneFooterAddressCommandResult(request.Id);

        }
    }
}
