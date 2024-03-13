using Application.Features.CQRS.Commands.ProvidedServiceCommands;
using Application.Features.CQRS.Results.AboutResults;
using Application.Features.CQRS.Results.ProvidedServiceResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForProvidedService;
using MediatR;

namespace Application.Features.CQRS.Handlers.ProvidedServiceHandlers
{
    public class UpdateOneProvidedServiceCommandHandler : IRequestHandler<UpdateOneProvidedServiceCommand, UpdateOneProvidedServiceCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOneProvidedServiceCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOneProvidedServiceCommandResult> Handle(UpdateOneProvidedServiceCommand request, CancellationToken cancellationToken)
        {
    
            ProvidedService? unchangedService = _repositoryManager.ProvidedServiceRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if(unchangedService is null)
                throw new ProvidedServiceNotFoundException(request.Id);
            unchangedService.Title = request.Title;
            unchangedService.IsActive = request.IsActive;
            if (request.IsActive) unchangedService.IsDeleted = false; else unchangedService.IsDeleted = true;
            unchangedService.ModifiedDate = DateTime.UtcNow;
            unchangedService.Description = request.Description;
            unchangedService.IconUrl = request.IconUrl;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneProvidedServiceCommandResult>(unchangedService);

           
        }
    }
}
