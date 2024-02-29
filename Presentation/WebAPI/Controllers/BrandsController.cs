using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Handlers.BrandHandlers;
using Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetOneBrandByIdQueryHandler _getOneBrandByIdQueryHandler;
        private readonly GetAllBrandsQueryHandler _getAllBrandsQueryHandler;
        private readonly CreateOneBrandCommandHandler _createOneBrandCommandHandler;
        private readonly UpdateOneBrandCommandHandler _updateOneBrandCommandHandler;
        private readonly RemoveOneBrandCommandHandler _removeOneBrandCommandHandler;

        public BrandsController(GetOneBrandByIdQueryHandler getOneBrandByIdQueryHandler, GetAllBrandsQueryHandler getAllBrandsQueryHandler, CreateOneBrandCommandHandler createOneBrandCommandHandler, UpdateOneBrandCommandHandler updateOneBrandCommandHandler, RemoveOneBrandCommandHandler removeOneBrandCommandHandler)
        {
            _getOneBrandByIdQueryHandler = getOneBrandByIdQueryHandler;
            _getAllBrandsQueryHandler = getAllBrandsQueryHandler;
            _createOneBrandCommandHandler = createOneBrandCommandHandler;
            _updateOneBrandCommandHandler = updateOneBrandCommandHandler;
            _removeOneBrandCommandHandler = removeOneBrandCommandHandler;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBrand([FromRoute(Name="id")]int id)
        {
            var result = _getOneBrandByIdQueryHandler.Handle(new GetOneBrandByIdQuery(id));
            return StatusCode(200,result); 
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var result = await _getAllBrandsQueryHandler.Handle();
            return StatusCode(200,result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneBrand([FromBody]CreateOneBrandCommand command)
        {
            var result = await _createOneBrandCommandHandler.Handle(command);
            return StatusCode(201,result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBrand([FromRoute(Name="id")]int id,UpdateOneBrandCommand command)
        {
            var result = await _updateOneBrandCommandHandler.Handle(command);
            return StatusCode(201,result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBrand([FromRoute(Name ="id")]int id,RemoveOneBrandCommand command)
        {
            var result = await _removeOneBrandCommandHandler.Handle(command);
            return StatusCode(201, result);

        }
    }
}
