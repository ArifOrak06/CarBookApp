using Application.Features.CQRS.Commands.SocialMediaCommands;
using Application.Features.CQRS.Queries.SocialMediaQueries;
using Domain.Exceptions.ExceptionsForSocialMedia;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneSocialMedia([FromRoute(Name="id")]int id)
        {
            var result = await _mediator.Send(new GetOneSocialMediaByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSocialMedias()
        {
            var result = await _mediator.Send(new GetAllSocialMediasQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneSocialMedia([FromBody]CreateOneSocialMediaCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(201,result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneSocialMedia([FromRoute(Name="id")]int id,[FromBody]UpdateOneSocialMediaCommand command)
        {
            if (id != command.Id)
                throw new SocialMediaNotMatchedParametersBadRequestException(id);
            var result = await _mediator.Send(command);
            return StatusCode(201, result); 
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneSocialMedia([FromRoute(Name="id")]int id)
        {
            var result = await _mediator.Send(new RemoveOneSocialMediaCommand(id));
            return StatusCode(204);
        }
    }
}
