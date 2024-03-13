using Application.Features.CQRS.Commands.FooterAddressCommands;
using Application.Features.CQRS.Results.FooterAddressResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForFooterAddress;
using MediatR;

namespace Application.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class UpdateOneFooterAddressCommandHandler : IRequestHandler<UpdateOneFooterAddressCommand, UpdateOneFooterAddressCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOneFooterAddressCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateOneFooterAddressCommandResult> Handle(UpdateOneFooterAddressCommand request, CancellationToken cancellationToken)
        {
          
            var unchangedEntity = _repositoryManager.FooterAdressRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (unchangedEntity == null)
                throw new FooterAddressNotFoundException(request.Id);
            unchangedEntity.IsActive = request.IsActive;
            unchangedEntity.Description = request.Description;
            unchangedEntity.ModifiedDate = DateTime.UtcNow;
            unchangedEntity.Phone = request.Phone;
            unchangedEntity.Address = request.Address;
            unchangedEntity.Email = request.Email;
            if (request.IsActive) unchangedEntity.IsDeleted = false; else unchangedEntity.IsDeleted = true;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneFooterAddressCommandResult>(request);

            
        }
    }
}
