﻿using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Queries.CarQueries;
using Domain.Exceptions.ExceptionsForCar;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetOneCarByIdQueryHandler _getOneCarByIdQueryHandler;
        private readonly GetAllCarsQueryHandler _getAllCarsQueryHandler;
        private readonly CreateOneCarCommandHandler _createOneCarCommandHandler;
        private readonly UpdateOneCarCommandHandler _updateOneCarCommandHandler;
        private readonly RemoveOneCarCommandHandler _removeOneCarCommandHandler;

        public CarsController(GetOneCarByIdQueryHandler getOneCarByIdQueryHandler, GetAllCarsQueryHandler getAllCarsQueryHandler, CreateOneCarCommandHandler createOneCarCommandHandler, UpdateOneCarCommandHandler updateOneCarCommandHandler, RemoveOneCarCommandHandler removeOneCarCommandHandler)
        {
            _getOneCarByIdQueryHandler = getOneCarByIdQueryHandler;
            _getAllCarsQueryHandler = getAllCarsQueryHandler;
            _createOneCarCommandHandler = createOneCarCommandHandler;
            _updateOneCarCommandHandler = updateOneCarCommandHandler;
            _removeOneCarCommandHandler = removeOneCarCommandHandler;
        }


        [HttpGet("{id:int}")]
        public IActionResult GetOneCar([FromRoute(Name="id")]int id,GetOneCarByIdQuery query)
        {
            var result = _getOneCarByIdQueryHandler.Handle(query);
            return StatusCode(200, result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var result = await _getAllCarsQueryHandler.Handle();
            return StatusCode(200, result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneCar(CreateOneCarCommand command)
        {
            var result = await _createOneCarCommandHandler.Handle(command);
            return StatusCode(201,result);

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCar([FromRoute(Name="id")]int id,[FromBody]RemoveOneCarCommand command)
        {
            if (id != command.Id)
                throw new CarNotMatchedParametersBadRequestException(id);
            var result = await _removeOneCarCommandHandler.Handle(command);
            return StatusCode(204, result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCar([FromRoute(Name ="id")]int id, UpdateOneCarCommand command)
        {
            if (id != command.Id)
                throw new CarNotMatchedParametersBadRequestException(id);
            var result = await _updateOneCarCommandHandler.Handle(command);
            return StatusCode(201, result);
        }
    }
}