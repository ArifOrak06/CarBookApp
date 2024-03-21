using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Results.ContactResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForContact;
using MediatR;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateOneContactCommandHandler : IRequestHandler<UpdateOneContactCommand,UpdateOneContactCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOneContactCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOneContactCommandResult> Handle(UpdateOneContactCommand request, CancellationToken cancellationToken)
        {
            var unchangedEntity = _repositoryManager.ContactRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (unchangedEntity == null)
                throw new ContactNotFoundException(request.Id);
            unchangedEntity.ModifiedDate = DateTime.UtcNow;
            unchangedEntity.IsDeleted = request.IsDeleted;
            unchangedEntity.IsActive = request.IsActive;
            unchangedEntity.Subject = request.Subject;
            unchangedEntity.Message = request.Message;
            unchangedEntity.Name = request.Name;
            unchangedEntity.Email = request.Email;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneContactCommandResult>(unchangedEntity);
        }
    }
}
