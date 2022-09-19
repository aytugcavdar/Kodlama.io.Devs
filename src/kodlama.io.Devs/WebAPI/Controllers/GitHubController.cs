using Application.Features.SocialMedia.GitHubProfile.commands.CreateGitHub;
using Application.Features.SocialMedia.GitHubProfile.Commands.DeleteGitHub;
using Application.Features.SocialMedia.GitHubProfile.Commands.UpdateGitHub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddGitHub([FromBody] CreateGitHubCommand createGitHubCommand)
        {
            var result = await Mediator!.Send(createGitHubCommand);

            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteGitHub([FromRoute] DeleteGitHubCommand deleteGitHub)
        {
            var result = await Mediator!.Send(deleteGitHub);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGitHub([FromBody] UpdateGitHubCommand updateGitHub)
        {
            var result = await Mediator!.Send(updateGitHub);

            return Ok(result);
        }
    }
    
}
