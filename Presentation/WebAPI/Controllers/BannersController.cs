using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Features.CQRS.Queries.BannerQueries;
using Domain.Exceptions.ExceptionsForBanner;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetOneBannerByIdQueryHandler _getOneBannerByIdQueryHandler;
        private readonly GetAllBannersQueryHandler _getAllBannersQueryHandler;
        private readonly CreateOneBannerCommandHandler _createOneBannerCommandHandler;
        private readonly UpdateOneBannerCommandHandler _updateOneBannerCommandHandler;
        private readonly RemoveOneBannerCommandHandler _removeOneBannerCommandHandler;

        public BannersController(GetOneBannerByIdQueryHandler getOneBannerByIdQueryHandler, GetAllBannersQueryHandler getAllBannersQueryHandler, CreateOneBannerCommandHandler createOneBannerCommandHandler, UpdateOneBannerCommandHandler updateOneBannerCommandHandler, RemoveOneBannerCommandHandler removeOneBannerCommandHandler)
        {
            _getOneBannerByIdQueryHandler = getOneBannerByIdQueryHandler;
            _getAllBannersQueryHandler = getAllBannersQueryHandler;
            _createOneBannerCommandHandler = createOneBannerCommandHandler;
            _updateOneBannerCommandHandler = updateOneBannerCommandHandler;
            _removeOneBannerCommandHandler = removeOneBannerCommandHandler;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBanner([FromRoute(Name = "id")] int id)
        {
            var result = _getOneBannerByIdQueryHandler.Handle(new GetOneBannerByIdQuery(id));
            return StatusCode(200, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBanners()
        {
            var result = await _getAllBannersQueryHandler.Handle();
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneBanner(CreateOneBannerCommand command)
        {
            var result = await _createOneBannerCommandHandler.Handle(command);
            return StatusCode(201, result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBanner([FromRoute(Name = "id")]int id, UpdateOneBannerCommand command)
        {
            if (id != command.Id)
                throw new BannerNotMatchedParametersBadRequestException(id);
            var result = await _updateOneBannerCommandHandler.Handle(command);
            return StatusCode(201, result);            
        }
        [HttpDelete("{id:int}")]
        public  IActionResult DeleteOneBanner([FromRoute(Name="id")]int id,RemoveOneBannerCommand command)
        {
            if (id != command.Id)
                throw new BannerNotMatchedParametersBadRequestException(command.Id);
            var result =  _removeOneBannerCommandHandler.Handle(command);
            return StatusCode(204, result);
        }

    }
}
