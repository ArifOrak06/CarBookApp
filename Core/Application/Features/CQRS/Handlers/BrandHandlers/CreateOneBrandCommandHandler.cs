using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Results.AboutResults;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForBrand;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateOneBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOneBrandCommandHandler(IRepository<Brand> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetOneBrandByIdQueryResult> Handle(CreateOneBrandCommand createOneBrandCommand)
        {
            if (createOneBrandCommand == null)
                throw new BrandObjectNullBadRequestException();

            var newEntity = _mapper.Map<Brand>(createOneBrandCommand);
            await _repository.CreateAsync(newEntity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<GetOneBrandByIdQueryResult>(newEntity);
        }
    }
}
