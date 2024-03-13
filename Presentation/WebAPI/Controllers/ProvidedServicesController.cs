using Application.Features.CQRS.Commands.ProvidedServiceCommands;
using Application.Features.CQRS.Queries.ProvidedServiceQueries;
using Domain.Exceptions.ExceptionsForProvidedService;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidedServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProvidedServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneProvidedService([FromRoute(Name="id")]int id)
        {
            var result = await _mediator.Send(new GetOneProvidedServiceByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProvidedServices()
        {
            var result = await _mediator.Send(new GetAllProvidedServicesQuery());   
            return Ok(result);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneProvidedService([FromBody]CreateOneProvidedServiceCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(201, result); 
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneProvidedService([FromRoute(Name="id")]int id, [FromBody]UpdateOneProvidedServiceCommand command)
        {
            if (id != command.Id)
                throw new ProvidedServiceNotMatchedParametersBadRequestException(id);
            var result = await _mediator.Send(command);
            return StatusCode(201,result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneProvidedService([FromRoute(Name="id")]int id)
        {
            var result = await _mediator.Send(new RemoveOneProvidedServiceCommand(id));
            return StatusCode(204);
        }
    }
}
