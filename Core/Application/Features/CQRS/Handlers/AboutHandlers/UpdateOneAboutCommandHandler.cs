using Application.Features.CQRS.Commands.AboutCommands;
using Application.Features.CQRS.Results.AboutResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateOneAboutCommandHandler : IRequestHandler<UpdateOneAboutCommand,UpdateOneAboutCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOneAboutCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOneAboutCommandResult> Handle(UpdateOneAboutCommand request, CancellationToken cancellationToken)
        {
            var result = _repositoryManager.AboutRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (result is null)
                throw new AboutNotFoundException(request.Id);

            result.Title = request.Title;
            result.Description = request.Description;
            result.IsActive = request.IsActive;
            result.ModifiedDate = DateTime.UtcNow;
            if (request.IsActive) result.IsDeleted = false; else result.IsDeleted = true;
            if (request.ImageUrl != null)
                result.ImageUrl = request.ImageUrl;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneAboutCommandResult>(result);
        }
    }
}
