using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPC.Application.Features.Commands.Link.CreateLink;
using PPC.Application.Features.Commands.Link.RemoveLink;
using PPC.Application.Features.Commands.Link.UpdateLink;
using PPC.Application.Features.Queries.Link.GetUserLinks;
using System.IdentityModel.Tokens.Jwt;

namespace PPC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LinksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserLinks([FromRoute] GetUserLinksQueryRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateLink(CreateLinkCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateLink(UpdateLinkCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveLink([FromRoute] RemoveLinkCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }

    }
}
