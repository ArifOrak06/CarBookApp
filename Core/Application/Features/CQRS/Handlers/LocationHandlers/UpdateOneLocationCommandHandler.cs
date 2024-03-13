using Application.Features.CQRS.Commands.LocationCommands;
using Application.Features.CQRS.Results.LocationResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForLocation;
using MediatR;

namespace Application.Features.CQRS.Handlers.LocationHandlers
{
    public class UpdateOneLocationCommandHandler : IRequestHandler<UpdateOneLocationCommand, UpdateOneLocationCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOneLocationCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOneLocationCommandResult> Handle(UpdateOneLocationCommand request, CancellationToken cancellationToken)
        {
       
            var unchangedLocation = _repositoryManager.LocationRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if(unchangedLocation == null)
                throw new LocationNotFoundException(request.Id);
            unchangedLocation.Name = request.Name;
            unchangedLocation.ModifiedDate = DateTime.UtcNow;
            unchangedLocation.IsActive = request.IsActive;
            if (request.IsActive) unchangedLocation.IsDeleted = false; else unchangedLocation.IsDeleted = true;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneLocationCommandResult>(unchangedLocation);
            
        }
    }
}
