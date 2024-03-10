using Application.Features.CQRS.Commands.ProvidedServiceCommands;
using Application.Features.CQRS.Results.ProvidedServiceResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForProvidedService;
using MediatR;

namespace Application.Features.CQRS.Handlers.ProvidedServiceHandlers
{
    public class CreateOneProvidedServiceCommandHandler : IRequestHandler<CreateOneProvidedServiceCommand, CreateOneProvidedServiceCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOneProvidedServiceCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateOneProvidedServiceCommandResult> Handle(CreateOneProvidedServiceCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ProvidedServiceObjectNullBadRequestException();

            var newService = _mapper.Map<ProvidedService>(request);
            newService.IsActive = true;
            newService.IsDeleted = false;
            newService.CreatedDate = DateTime.UtcNow;
            await _repositoryManager.ProvidedServiceRepository.CreateAsync(newService);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOneProvidedServiceCommandResult>(newService);

        }
    }
}
