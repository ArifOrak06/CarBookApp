using Application.Features.CQRS.Commands;
using Application.Features.CQRS.Commands.AboutCommands;
using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateOneAboutCommandHandler _createOneAboutCommandHandler;
        private readonly RemoveOneAboutCommandHandler _removeOneAboutCommandHandler;
        private readonly UpdateOneAboutCommandHandler _updateOneAboutCommandHandler;
        private readonly GetOneAboutByIdQueryHandler _getOneAboutByIdQueryHandler;
        private readonly GetAllAboutsQueryHandler _getAllAboutsQueryHandler;

        public AboutsController(CreateOneAboutCommandHandler createOneAboutCommandHandler, RemoveOneAboutCommandHandler removeOneAboutCommandHandler, UpdateOneAboutCommandHandler updateOneAboutCommandHandler, GetOneAboutByIdQueryHandler getOneAboutByIdQueryHandler, GetAllAboutsQueryHandler getAllAboutsQueryHandler)
        {
            _createOneAboutCommandHandler = createOneAboutCommandHandler;
            _removeOneAboutCommandHandler = removeOneAboutCommandHandler;
            _updateOneAboutCommandHandler = updateOneAboutCommandHandler;
            _getOneAboutByIdQueryHandler = getOneAboutByIdQueryHandler;
            _getAllAboutsQueryHandler = getAllAboutsQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbouts()
        {
            var result = await _getAllAboutsQueryHandler.Handle();
            return StatusCode(200,result);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneAbout([FromRoute(Name ="id")]int id)
        {
            var result = _getOneAboutByIdQueryHandler.Handle(new GetOneAboutByIdQuery(id));
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> AddOneAbout(CreateOneAboutCommand command)
        {
            var result = await _createOneAboutCommandHandler.Handle(command);
            return StatusCode(200, result);
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneAbout(RemoveOneAboutCommand command)
        {
            var result =  _removeOneAboutCommandHandler.Handle(command);
            return StatusCode(204, result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneAbout([FromRoute(Name="id")]int id,UpdateOneAboutCommand command)
        {
            var result = await _updateOneAboutCommandHandler.Handle(command);
            return StatusCode(200, result);
        }
    }
}
