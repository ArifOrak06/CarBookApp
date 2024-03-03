using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Results.BannerResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForBanner;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateOneBannerCommandHandler
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

        public async Task<UpdateOneBannerCommandResult> Handle(UpdateOneBannerCommand updateOneBannerCommand)
        {
            if (updateOneBannerCommand == null)
                throw new BannerObjectNullBadRequestException();
            var currentEntity = _repositoryManager.BannerRepository.GetByFilter(x => x.Id == updateOneBannerCommand.Id, true).SingleOrDefault();
            if (currentEntity == null)
                throw new BannerNotFoundException(updateOneBannerCommand.Id);

            _repositoryManager.BannerRepository.Update(_mapper.Map<Banner>(updateOneBannerCommand));
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneBannerCommandResult>(currentEntity);

        }
    }
}
