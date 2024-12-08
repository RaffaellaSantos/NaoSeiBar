using Microsoft.AspNetCore.Mvc;
using Nao_Sei_Bar_Backend.src.services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NSB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(LoginService loginService) : ControllerBase
    {
        private readonly LoginService _loginService = loginService;

        [HttpPost("login")]
        public async Task<Boolean> Login([FromForm] LoginDto loginDto)
        {

            if (!ModelState.IsValid)
            {
                return false;
            }

            return await _loginService.ValidarLogin(loginDto);
        }
    }
}
