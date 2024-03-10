using Application.Features.CQRS.Commands.LocationCommands;
using Application.Features.CQRS.Results.LocationResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForLocation;
using MediatR;

namespace Application.Features.CQRS.Handlers.LocationHandlers
{
    public class CreateOneLocationCommandHandler : IRequestHandler<CreateOneLocationCommand, CreateOneLocationCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOneLocationCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateOneLocationCommandResult> Handle(CreateOneLocationCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new LocationObjectNullBadRequestException();
            var newLocation = _mapper.Map<Location>(request);
            newLocation.CreatedDate = DateTime.UtcNow;
            newLocation.IsActive = true;
            newLocation.IsDeleted = false;
            await _repositoryManager.LocationRepository.CreateAsync(newLocation);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOneLocationCommandResult>(newLocation);
            
        }
    }
}
