using Microsoft.AspNetCore.Mvc;
using Nao_Sei_Bar_Backend.src.services.interfaces;
using Nao_Sei_Bar_Backend.src.validators;
using NaoSeiBar.src.data.entities;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NSB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(ILogin loginService, LoginValidator validator, IFuncionario funcionario) : ControllerBase
    {
        private readonly ILogin _loginService = loginService;
        private readonly LoginValidator _validator = validator;
        private readonly IFuncionario funcionario = funcionario;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {

            FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            bool isValid = await _loginService.ValidarLoginAsync(request.Cpf, request.Senha);
            if (!isValid)
            {
                return Unauthorized("Login ou senha inválidos.");
            }


            //var funcionario = await _loginService.ObterFuncionarioPorCpf(request.Cpf);
            var paginaAutorizada = await _loginService.ObterPaginaAutorizada(funcionario.Funcao);

            return Ok(new { Message = "Login bem-sucedido!", PaginaAutorizada = paginaAutorizada });
        }
    }
}
