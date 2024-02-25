using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.CQRS.Results;
using Application.Repositories;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetOneAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetOneAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public GetOneAboutByIdQueryResult Handle(GetOneAboutByIdQuery getOneAboutByIdQuery)
        {
            var newAbout = _repository.GetByFilter(x => x.Id == getOneAboutByIdQuery.Id, false).SingleOrDefault();
            if (newAbout == null)
                throw new AboutNotFoundException(getOneAboutByIdQuery.Id);

            return new GetOneAboutByIdQueryResult
            {
                Id = newAbout.Id,
                Description = newAbout.Description,
                ImageUrl = newAbout.ImageUrl,
                Title = newAbout.Title
            };
        }
    }
}
