using Application.Features.CQRS.Commands.BrandCommands;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForBrand;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveOneBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RemoveOneBrandCommandHandler(IRepository<Brand> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(RemoveOneBrandCommand removeOneBrandCommand)
        {
            if (removeOneBrandCommand is null)
                throw new BrandObjectNullBadRequestException();
            var currentEntity = _repository.GetByFilter(x => x.Id.Equals(removeOneBrandCommand.Id), true).SingleOrDefault();
            if (currentEntity is null)
                throw new BrandNotFoundException(removeOneBrandCommand.Id);

            _repository.Delete(currentEntity);
            await _unitOfWork.CommitAsync();
            return removeOneBrandCommand.Id;

        }
    }
}
