using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Results.BannerResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForBanner;
using MediatR;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateOneBannerCommandHandler : IRequestHandler<UpdateOneBannerCommand,UpdateOneBannerCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOneBannerCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateOneBannerCommandResult> Handle(UpdateOneBannerCommand request, CancellationToken cancellationToken)
        {
            var currentEntity = _repositoryManager.BannerRepository.GetByFilter(x => x.Id == request.Id, true).SingleOrDefault();
            if (currentEntity == null)
                throw new BannerNotFoundException(request.Id);
            currentEntity.Description = request.Description;
            currentEntity.VideoDescription = request.VideoDescription;
            currentEntity.VideoUrl = request.VideoUrl;
            currentEntity.Title = request.Title;

            currentEntity.IsActive = request.IsActive;
            if (request.IsActive) currentEntity.IsDeleted = false; else currentEntity.IsDeleted = true;
            currentEntity.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneBannerCommandResult>(currentEntity);
        }
    }
}
