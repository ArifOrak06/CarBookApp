using Application.Features.CQRS.Commands.ContactCommands;
using Application.Features.CQRS.Results.ContactResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateOneContactCommandHandler : IRequestHandler<CreateOneContactCommand,CreateOneContactCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOneContactCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateOneContactCommandResult> Handle(CreateOneContactCommand request, CancellationToken cancellationToken)
        {
            var newContact = _mapper.Map<Contact>(request);
            newContact.CreatedDate = DateTime.UtcNow;
            newContact.IsActive = true;
            newContact.IsDeleted = false;
            await _repositoryManager.ContactRepository.CreateAsync(newContact);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOneContactCommandResult>(newContact);
        }
    }
}
