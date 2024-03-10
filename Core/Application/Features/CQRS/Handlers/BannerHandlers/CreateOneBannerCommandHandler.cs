using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Results.BannerResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForBanner;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateOneBannerCommandHandler 
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOneBannerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IRepositoryManager repositoryManager)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<CreateOneBannerCommandResult> Handle(CreateOneBannerCommand createOneBannerCommand)
        {
            if (createOneBannerCommand == null)
                throw new BannerObjectNullBadRequestException();
            var newBanner = _mapper.Map<Banner>(createOneBannerCommand);
            newBanner.CreatedDate = DateTime.UtcNow;
            newBanner.IsActive = true;
            newBanner.IsDeleted = false;
            var result = await _repositoryManager.BannerRepository.CreateAsync(newBanner);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOneBannerCommandResult>(newBanner);
        }
    }
}
