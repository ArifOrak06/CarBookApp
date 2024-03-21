using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Queries.CarQueries;
using Domain.Entities.RequestFeatures;
using Domain.Exceptions.ExceptionsForCar;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneCar([FromRoute(Name = "id")] int id)
        {
            var result = _mediator.Send(new GetOneCarByIdQuery(id));
            return StatusCode(200, result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var result = await _mediator.Send(new GetAllCarsQuery());
            return Ok(result);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneCar(CreateOneCarCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(201, result);

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCar([FromRoute(Name = "id")] int id, [FromBody] RemoveOneCarCommand command)
        {
            if (id != command.Id)
                throw new CarNotMatchedParametersBadRequestException(id);
            var result = await _mediator.Send(command);
            return StatusCode(204, result);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCar([FromRoute(Name = "id")] int id, UpdateOneCarCommand command)
        {
            if (id != command.Id)
                throw new CarNotMatchedParametersBadRequestException(id);
            var result = await _mediator.Send(command);
            return StatusCode(201, result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCarWithBrand([FromRoute(Name="id")]int id)
        {
            var result = await _mediator.Send(new GetOneCarByIdQuery(id));
            return StatusCode(200, result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCarsWithBrands([FromQuery]CarRequestParameters carRequestParameters)
        {
            var pagedResult = await _mediator.Send(new GetAllCarsWithBrandsQuery(carRequestParameters.PageNumber,carRequestParameters.PageSize));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return StatusCode(200, pagedResult.result);
        }
    }
}
