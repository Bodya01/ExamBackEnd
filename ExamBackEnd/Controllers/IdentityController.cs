using Exam.Domain.Dto.UserDtos.Login;
using Exam.Domain.Dto.UserDtos.Refresh;
using Exam.Domain.Dto.UserDtos.Registration;
using Exam.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exam.WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDto registrationDto)
        {
            var (isSuccessful, authResult) = await identityService.RegisterAsync(registrationDto);
            return isSuccessful ? Ok(authResult) : BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var (isSuccessful, authResult) = await identityService.LoginAsync(loginDto);
            return isSuccessful ? Ok(authResult) : BadRequest();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var (isSuccessful, authResult) = await identityService.RefreshAsync(refreshTokenDto);
            return isSuccessful ? Ok(authResult) : Forbid();
        }
    }
}
