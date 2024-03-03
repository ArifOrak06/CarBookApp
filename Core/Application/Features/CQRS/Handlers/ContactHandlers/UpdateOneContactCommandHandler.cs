using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Results.ContactResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForContact;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateOneContactCommandHandler
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

        public async Task<UpdateOneContactCommandResult> Handle(UpdateOneContactCommand updateOneContactCommand)
        {
            if (updateOneContactCommand == null)
                throw new ContactObjectNullBadRequestException();
            var unchangedEntity = _repositoryManager.ContactRepository.GetByFilter(x => x.Id.Equals(updateOneContactCommand.Id), true).SingleOrDefault();
            if (unchangedEntity == null)
                throw new ContactNotFoundException(updateOneContactCommand.Id);
            unchangedEntity.SendDate = updateOneContactCommand.SendDate;
            unchangedEntity.ModifiedDate = DateTime.UtcNow;
            unchangedEntity.IsDeleted = updateOneContactCommand.IsDeleted;
            unchangedEntity.IsActive = updateOneContactCommand.IsActive;
            unchangedEntity.Subject = updateOneContactCommand.Subject;
            unchangedEntity.Message = updateOneContactCommand.Message;
            unchangedEntity.Name = updateOneContactCommand.Name;
            unchangedEntity.Email = updateOneContactCommand.Email;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneContactCommandResult>(unchangedEntity);

        }
    }
}
