using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Handlers.CategoryHandlers;
using Application.Features.CQRS.Queries.CategoryQueries;
using Domain.Exceptions.ExceptionsForCategory;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetOneCategoryByIdQueryHandler _getOneCategoryByIdQueryHandler;
        private readonly GetAllCategoriesQueryHandler _getAllCategoriesQueryHandler;
        private readonly CreateOneCategoryCommandHandler _createOneCategoryCommandHandler;
        private readonly UpdateOneCategoryCommandHandler _updateOneCategoryCommandHandler;
        private readonly RemoveOneCategoryCommandHandler _removeOneCategoryCommandHandler;

        public CategoriesController(GetOneCategoryByIdQueryHandler getOneCategoryByIdQueryHandler, GetAllCategoriesQueryHandler getAllCategoriesQueryHandler, CreateOneCategoryCommandHandler createOneCategoryCommandHandler, UpdateOneCategoryCommandHandler updateOneCategoryCommandHandler, RemoveOneCategoryCommandHandler removeOneCategoryCommandHandler)
        {
            _getOneCategoryByIdQueryHandler = getOneCategoryByIdQueryHandler;
            _getAllCategoriesQueryHandler = getAllCategoriesQueryHandler;
            _createOneCategoryCommandHandler = createOneCategoryCommandHandler;
            _updateOneCategoryCommandHandler = updateOneCategoryCommandHandler;
            _removeOneCategoryCommandHandler = removeOneCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _getAllCategoriesQueryHandler.Handle();
            return StatusCode(200, result);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneCategory([FromRoute(Name="id")]int id)
        {
            var result = _getOneCategoryByIdQueryHandler.Handle(new GetOneCategoryByIdQuery(id));
            return StatusCode(200, result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneCategory([FromBody]CreateOneCategoryCommand createOneCategoryCommand)
        {
            var result = await _createOneCategoryCommandHandler.Handle(createOneCategoryCommand);
            return StatusCode(201, result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCategory([FromRoute(Name="id")]int id, UpdateOneCategoryCommand updateOneCategoryCommand)
        {
            if (id != updateOneCategoryCommand.Id)
                throw new CategoryNotMatchedParametersBadRequestException(id);
            var result = await _updateOneCategoryCommandHandler.Handle(updateOneCategoryCommand);
            return StatusCode(201, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveOneCategory([FromRoute(Name="id")]int id)
        {
            var result = await _removeOneCategoryCommandHandler.Handle(new RemoveOneCategoryCommand(id));
            return StatusCode(200, result);
        }
    }
}
