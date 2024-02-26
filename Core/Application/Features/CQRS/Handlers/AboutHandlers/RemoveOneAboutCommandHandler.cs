using Application.Features.CQRS.Commands.AboutCommands;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveOneAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOneAboutCommandHandler(IRepository<About> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(RemoveOneAboutCommand removeOneAboutCommand)
        {
            var currentAbout = _repository.GetByFilter(x => x.Id.Equals(removeOneAboutCommand.Id), true).SingleOrDefault();
            if (currentAbout is null)
                throw new AboutNotFoundException(removeOneAboutCommand.Id);

            _repository.Delete(currentAbout);
            await _unitOfWork.CommitAsync();


        }
    }
}
