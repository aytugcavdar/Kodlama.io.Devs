using Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Models;
using Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Kodlama.io.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyQuery;
using Application.Features.ProgrammingTechnologies.Queries.GetListByIdProgrammingTechnologyQuery;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingTechnologyController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingTechnologyCommand createProgrammingTechnologyCommand)
        {
            CreatedProgrammingTechnologyDto createdProgrammingTechnologyDto = await Mediator.Send(createProgrammingTechnologyCommand);
            return Created("", createdProgrammingTechnologyDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingTechnologyQuery getListProgrammingTechnologyQuery = new() { PageRequest = pageRequest };
            ProgrammingTechnologyListModel result = await Mediator.Send(getListProgrammingTechnologyQuery);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingTechnologyCommand deleteProgrammingTechnologyCommand)
        {
            DeletedProgrammingTechnologyDto deletedProgrammingTechnologyDto = await Mediator.Send(deleteProgrammingTechnologyCommand);
            return Ok(deletedProgrammingTechnologyDto);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingTechnologyCommand updatedProgrammingTechnologyCommand)
        {
            UpdatedProgrammingTechnologyDto updatedProgrammingTechnologyDto = await Mediator.Send(updatedProgrammingTechnologyCommand);
            return Ok(updatedProgrammingTechnologyDto);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetListByIdProgrammingTechnologyQuery getListByIdProgrammingTechnologyQuery)
        {
            GetListByIdProgrammingTechnologyDto getListByIdProgrammingTechnologyDto = await Mediator.Send(getListByIdProgrammingTechnologyQuery);
            return Ok(getListByIdProgrammingTechnologyDto);
        }
    }
}
