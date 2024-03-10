using Application.Features.CQRS.Commands.ProvidedServiceCommands;
using Application.Features.CQRS.Results.ProvidedServiceResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForProvidedService;
using MediatR;

namespace Application.Features.CQRS.Handlers.ProvidedServiceHandlers
{
    public class RemoveOneProvidedServiceCommandHandler : IRequestHandler<RemoveOneProvidedServiceCommand, RemoveOneProvidedServiceCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RemoveOneProvidedServiceCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RemoveOneProvidedServiceCommandResult> Handle(RemoveOneProvidedServiceCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ProvidedServiceObjectNullBadRequestException();
            var deletedEntity = _repositoryManager.ProvidedServiceRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (deletedEntity == null)
                throw new ProvidedServiceNotFoundException(request.Id);
            _repositoryManager.ProvidedServiceRepository.Delete(deletedEntity);
            await _unitOfWork.CommitAsync();
            return new RemoveOneProvidedServiceCommandResult(request.Id);

            
        }
    }
}
