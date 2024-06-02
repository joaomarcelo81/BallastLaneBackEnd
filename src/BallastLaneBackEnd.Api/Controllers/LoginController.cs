using BallastLaneBackEnd.Domain.DTO.Login;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BallastLaneBackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;
        private readonly IUserService _loginService;
        private readonly IHttpContextAccessor _accessor;

        public LoginController(
            ILogger<LoginController> logger,
            IUserService loginService, IHttpContextAccessor accessor)
        {
            _loginService = loginService;
            _accessor = accessor;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> PostByTokenAsync(UserRequest loginRequest)
        {
            var result = await _loginService.GenerateTokenAsync(loginRequest);
            if (result != null)
                return Ok(result);

            _logger.LogError($" _logger LogError Login error : {loginRequest.Login}/{loginRequest.Password} ");
            _logger.LogInformation($"_logger LogInformation Login error : {loginRequest.Login}/{loginRequest.Password} ");

            return BadRequest(result);
        }
    }
}
