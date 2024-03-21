using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Queries.BannerQueries;
using Domain.Exceptions.ExceptionsForBanner;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BannersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBanner([FromRoute(Name = "id")] int id)
        {
            var result = _mediator.Send(new GetOneBannerByIdQuery(id));
            return StatusCode(200, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBanners()
        {
            var result = await _mediator.Send(new GetAllBannersQuery());
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneBanner(CreateOneBannerCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(201, result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBanner([FromRoute(Name = "id")]int id, UpdateOneBannerCommand command)
        {
            if (id != command.Id)
                throw new BannerNotMatchedParametersBadRequestException(id);
            var result = await _mediator.Send(command);
            return StatusCode(201, result);            
        }
        [HttpDelete("{id:int}")]
        public  IActionResult DeleteOneBanner([FromRoute(Name="id")]int id,RemoveOneBannerCommand command)
        {
            if (id != command.Id)
                throw new BannerNotMatchedParametersBadRequestException(command.Id);
            var result =  _mediator.Send(command);
            return StatusCode(204, result);
        }

    }
}
