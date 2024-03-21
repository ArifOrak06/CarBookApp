using Application.Features.CQRS.Commands;
using Application.Features.CQRS.Commands.AboutCommands;
using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Queries.AboutQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ActionFilters;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AboutsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbouts()
        {
            var result = await _mediator.Send(new GetAllAboutsQuery());
            return StatusCode(200,result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneAbout([FromRoute(Name ="id")]int id)
        {
            var result = await _mediator.Send(new GetOneAboutByIdQuery(id));
            return StatusCode(200, result);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> AddOneAbout(CreateOneAboutCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(200, result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneAbout(RemoveOneAboutCommand command)
        {
            var result =  await _mediator.Send(command);
            return StatusCode(204, result);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneAbout([FromRoute(Name="id")]int id,UpdateOneAboutCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(200, result);
        }
    }
}
