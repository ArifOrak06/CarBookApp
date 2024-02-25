using Application.Features.CQRS.Results;
using Application.Repositories;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAllAboutsQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAllAboutsQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllAboutsQueryResult>> Handle()
        {
            var results = await _repository.GetAllAsync(false);
            if (!results.Any())
                throw new Exception("Listeleme yapılacak About metni bulunmamaktadır.");

            return results.Select(x => new GetAllAboutsQueryResult
            {
                Description = x.Description,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Title = x.Title
            }).ToList();

        }
    }
}
