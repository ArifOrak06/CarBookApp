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
        private readonly IRepository<Banner> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOneBannerCommandHandler(IRepository<Banner> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateOneBannerCommandResult> Handle(CreateOneBannerCommand createOneBannerCommand)
        {
            if (createOneBannerCommand == null)
                throw new BannerObjectNullBadRequestException();
            var newBanner = _mapper.Map<Banner>(createOneBannerCommand);
            var result = await _repository.CreateAsync(newBanner);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOneBannerCommandResult>(newBanner);
        }
    }
}
