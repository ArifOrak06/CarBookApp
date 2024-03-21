using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Queries.CategoryQueries;
using Domain.Entities.RequestFeatures;
using Domain.Exceptions.ExceptionsForCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _meditor;

        public CategoriesController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery]CategoryRequestParameters categoryRequestParameters)
        {
            var result = await _meditor.Send(new GetAllCategoriesQuery(categoryRequestParameters.PageNumber,categoryRequestParameters.PageSize));
            return StatusCode(200, result);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneCategory([FromRoute(Name="id")]int id)
        {
            var result = _meditor.Send(new GetOneCategoryByIdQuery(id));
            return StatusCode(200, result);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneCategory([FromBody]CreateOneCategoryCommand createOneCategoryCommand)
        {
            var result = await _meditor.Send(createOneCategoryCommand);
            return StatusCode(201, result);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCategory([FromRoute(Name="id")]int id, UpdateOneCategoryCommand updateOneCategoryCommand)
        {
            if (id != updateOneCategoryCommand.Id)
                throw new CategoryNotMatchedParametersBadRequestException(id);
            var result = await _meditor.Send(updateOneCategoryCommand);
            return StatusCode(201, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveOneCategory([FromRoute(Name="id")]int id)
        {
            var result = await _meditor.Send(new RemoveOneCategoryCommand(id));
            return StatusCode(200, result);
        }
    }
}
