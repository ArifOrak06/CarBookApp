using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Commands.ContactCommands;
using Application.Features.CQRS.Handlers.ContactHandlers;
using Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetOneContactByIdQueryHandler _getOneContactByIdQueryHandler;
        private readonly GetAllContactsQueryHandler _getAllContactsQueryHandler;
        private readonly CreateOneContactCommandHandler _createOneContactCommandHandler;
        private readonly UpdateOneContactCommandHandler _updateOneContactCommandHandler;
        private readonly RemoveOneContactCommandHandler _removeOneContactCommandHandler;

        public ContactsController(GetOneContactByIdQueryHandler getOneContactByIdQueryHandler, GetAllContactsQueryHandler getAllContactsQueryHandler, CreateOneContactCommandHandler createOneContactCommandHandler, UpdateOneContactCommandHandler updateOneContactCommandHandler, RemoveOneContactCommandHandler removeOneContactCommandHandler)
        {
            _getOneContactByIdQueryHandler = getOneContactByIdQueryHandler;
            _getAllContactsQueryHandler = getAllContactsQueryHandler;
            _createOneContactCommandHandler = createOneContactCommandHandler;
            _updateOneContactCommandHandler = updateOneContactCommandHandler;
            _removeOneContactCommandHandler = removeOneContactCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var result = await _getAllContactsQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneContact([FromRoute(Name="id")]int id)
        {
            var result = _getOneContactByIdQueryHandler.Handle(new GetOneContactByIdQuery(id));
            return Ok(result);  
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneContact([FromBody]CreateOneContactCommand command)
        {
            var result = await _createOneContactCommandHandler.Handle(command);
            return StatusCode(201, result);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneContact([FromBody]UpdateOneContactCommand command)
        {
            var result = await _updateOneContactCommandHandler.Handle(command);
            return StatusCode(201, result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveOneCommand([FromRoute(Name="id")]int id)
        {
            var result = await _removeOneContactCommandHandler.Handle(new RemoveOneContactCommand(id));
            return StatusCode(201, result);

        }
    }
}
