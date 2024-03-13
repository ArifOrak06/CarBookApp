using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Queries.CarQueries;
using Domain.Exceptions.ExceptionsForCar;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetOneCarByIdQueryHandler _getOneCarByIdQueryHandler;
        private readonly GetAllCarsQueryHandler _getAllCarsQueryHandler;
        private readonly CreateOneCarCommandHandler _createOneCarCommandHandler;
        private readonly UpdateOneCarCommandHandler _updateOneCarCommandHandler;
        private readonly RemoveOneCarCommandHandler _removeOneCarCommandHandler;
        private readonly GetOneCarByIdWithBrandQueryHandler _getOneCarByIdWithBrandQueryHandler;
        private readonly GetAllCarsWithBrandsQueryHandler _getAllCarsWithBrandsQueryHandler;

        public CarsController(GetOneCarByIdQueryHandler getOneCarByIdQueryHandler, GetAllCarsQueryHandler getAllCarsQueryHandler, CreateOneCarCommandHandler createOneCarCommandHandler, UpdateOneCarCommandHandler updateOneCarCommandHandler, RemoveOneCarCommandHandler removeOneCarCommandHandler, GetOneCarByIdWithBrandQueryHandler getOneCarByIdWithBrandQueryHandler, GetAllCarsWithBrandsQueryHandler getAllCarsWithBrandsQueryHandler)
        {
            _getOneCarByIdQueryHandler = getOneCarByIdQueryHandler;
            _getAllCarsQueryHandler = getAllCarsQueryHandler;
            _createOneCarCommandHandler = createOneCarCommandHandler;
            _updateOneCarCommandHandler = updateOneCarCommandHandler;
            _removeOneCarCommandHandler = removeOneCarCommandHandler;
            _getOneCarByIdWithBrandQueryHandler = getOneCarByIdWithBrandQueryHandler;
            _getAllCarsWithBrandsQueryHandler = getAllCarsWithBrandsQueryHandler;
        }


        [HttpGet("{id:int}")]
        public IActionResult GetOneCar([FromRoute(Name = "id")] int id)
        {
            var result = _getOneCarByIdQueryHandler.Handle(new GetOneCarByIdQuery(id));
            return StatusCode(200, result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var result = await _getAllCarsQueryHandler.Handle();
            return StatusCode(200, result);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneCar(CreateOneCarCommand command)
        {
            var result = await _createOneCarCommandHandler.Handle(command);
            return StatusCode(201, result);

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCar([FromRoute(Name = "id")] int id, [FromBody] RemoveOneCarCommand command)
        {
            if (id != command.Id)
                throw new CarNotMatchedParametersBadRequestException(id);
            var result = await _removeOneCarCommandHandler.Handle(command);
            return StatusCode(204, result);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCar([FromRoute(Name = "id")] int id, UpdateOneCarCommand command)
        {
            if (id != command.Id)
                throw new CarNotMatchedParametersBadRequestException(id);
            var result = await _updateOneCarCommandHandler.Handle(command);
            return StatusCode(201, result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCarWithBrand([FromRoute(Name="id")]int id)
        {
            var result = await _getOneCarByIdWithBrandQueryHandler.Handle(new GetOneCarByIdQuery(id));
            return StatusCode(200, result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCarsWithBrands()
        {
            var result = await _getAllCarsWithBrandsQueryHandler.Handle();
            return StatusCode(200, result);
        }
    }
}
