using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenAuth.Service.DTOs;
using TokenAuth.Service.Services;

namespace TokenAuth.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentitiesController(IdentityService identityService, TokenService tokenService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateRequestDto request)
        {
            var response = await identityService.CreateUser(request);
            if (response.AnyError)
            {
                return BadRequest(response);
            }

            return Created("", response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(TokenCreateRequestDto request)
        {
            var response = await tokenService.Create(request);
            if (response.AnyError)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(RoleCreateRequestDto request)
        {
            var response = await identityService.CreateRole(request);
            if (response.AnyError)
            {
                return BadRequest(response);
            }

            return Created("", response);
        }
    }
}