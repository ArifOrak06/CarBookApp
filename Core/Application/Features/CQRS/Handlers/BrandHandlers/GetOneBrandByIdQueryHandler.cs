using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.ExceptionsForBrand;
using MediatR;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetOneBrandByIdQueryHandler : IRequestHandler<GetOneBrandByIdQuery,GetOneBrandByIdQueryResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneBrandByIdQueryHandler(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<GetOneBrandByIdQueryResult> Handle(GetOneBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var currentEntity = _repositoryManager.BrandRepository.GetByFilter(x => x.Id.Equals(request.Id), false).SingleOrDefault();
            if (currentEntity == null)
                throw new BrandNotFoundException(request.Id);
            return _mapper.Map<GetOneBrandByIdQueryResult>(currentEntity);
        }
    }
}
