
using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguages;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguages;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguages;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetListByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;

using Kodlama.io.Application.Requests;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguagesCommand)
        {
            CreatedProgrammingLanguageDto createdProgrammingLanguageDto = await Mediator.Send(createProgrammingLanguagesCommand);
            return Created("", createdProgrammingLanguageDto);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeleteProgrammingLanguageDto deletedProgrammingLanguageDto = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(deletedProgrammingLanguageDto);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguagesCommand)
        {
            UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = await Mediator.Send(updateProgrammingLanguagesCommand);
            return Ok(updatedProgrammingLanguageDto);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetListByIdProgrammingLanguageQuery getListByIdProgrammingLanguageQuery)
        {
            ProgrammingLanguageListByIdDto programmingLanguageListByIdDto = await Mediator.Send(getListByIdProgrammingLanguageQuery);
            return Ok(programmingLanguageListByIdDto);
        }

    }
}
