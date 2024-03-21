using Application.Features.CQRS.Commands;
using Application.Features.CQRS.Results.AboutResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateOneAboutCommandHandler : IRequestHandler<CreateOneAboutCommand,CreateOneAboutCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOneAboutCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        public async Task<CreateOneAboutCommandResult> Handle(CreateOneAboutCommand request, CancellationToken cancellationToken)
        {

            var newAbout = _mapper.Map<About>(request);
            newAbout.CreatedDate = DateTime.UtcNow;
            newAbout.IsActive = true;
            newAbout.IsDeleted = false;
            await _repositoryManager.AboutRepository.CreateAsync(newAbout);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<CreateOneAboutCommandResult>(newAbout);

        }
    }
}
