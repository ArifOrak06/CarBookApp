using Application.Features.CQRS.Commands.PricingCommands;
using Application.Features.CQRS.Queries.PricingQueries;
using Domain.Exceptions.ExceptionsForPricing;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOnePricing([FromRoute(Name="id")]int id)
        {
            var result = await _mediator.Send(new GetOnePricingByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPricings()
        {
            var result = await _mediator.Send(new GetAllPricingsQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOnePricing([FromBody]CreateOnePricingCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOnePricing([FromRoute(Name="id")]int id,UpdateOnePricingCommand command)
        {
            if (id != command.Id)
                throw new PricingNotMatchedBadRequestException(id);
            var result = await _mediator.Send(command);
            return StatusCode(201, result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOnePricing([FromRoute(Name="id")]int id)
        {
            var result = await _mediator.Send(new RemoveOnePricingCommand(id));
            return StatusCode(204);
        }
    }
}
