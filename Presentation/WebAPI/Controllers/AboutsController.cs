using Application.Features.CQRS.Handlers.AboutHandlers;
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

    }
}
