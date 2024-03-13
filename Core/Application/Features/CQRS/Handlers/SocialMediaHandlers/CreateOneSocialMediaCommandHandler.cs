using Application.Features.CQRS.Commands.SocialMediaCommands;
using Application.Features.CQRS.Results.SocialMediaResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForSocialMedia;
using MediatR;

namespace Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class CreateOneSocialMediaCommandHandler : IRequestHandler<CreateOneSocialMediaCommand, CreateOneSocialMediaCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOneSocialMediaCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateOneSocialMediaCommandResult> Handle(CreateOneSocialMediaCommand request, CancellationToken cancellationToken)
        {
            
            var newMedia = _mapper.Map<SocialMedia>(request);
            newMedia.CreatedDate = DateTime.UtcNow;
            newMedia.IsDeleted = false;
            newMedia.IsActive = true;
            await _repositoryManager.SocialMediaRepository.CreateAsync(newMedia);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOneSocialMediaCommandResult>(newMedia);
            
        }
    }
}
