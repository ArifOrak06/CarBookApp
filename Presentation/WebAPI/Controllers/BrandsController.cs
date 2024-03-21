using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Handlers.BrandHandlers;
using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Queries.CarQueries;
using Domain.Entities.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBrand([FromRoute(Name="id")]int id)
        {
            var result = _mediator.Send(new GetOneBrandByIdQuery(id));
            return StatusCode(200,result); 
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrands([FromQuery]BrandRequestParameters brandRequestParameters)
        {
            var result = await _mediator.Send(new GetAllBrandsQuery(brandRequestParameters.PageNumber,brandRequestParameters.PageSize));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));
            return StatusCode(200,result);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneBrand([FromBody]CreateOneBrandCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(201,result);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBrand([FromRoute(Name="id")]int id,UpdateOneBrandCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(201,result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBrand([FromRoute(Name ="id")]int id,RemoveOneBrandCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(201, result);

        }
        [HttpGet("{brandId:int}")]
        public async Task<IActionResult> GetOneBrandWithCars([FromRoute(Name="brandId")]int brandId)
        {
            var result = await _mediator.Send(new GetOneBrandByIdWithCarsQuery(brandId));
            return StatusCode(200, result);
        }
        
    }
}
