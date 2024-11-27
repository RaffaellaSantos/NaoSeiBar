using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Nao_Sei_Bar_Backend.src.services.interfaces;
using Nao_Sei_Bar_Backend.src.validators;
using NaoSeiBar.src.data.entities;

namespace Nao_Sei_Bar_Backend.src.controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _loginService;
        private readonly LoginValidator _validator;
        private readonly IFuncionario funcionario1;

        public LoginController(ILogin loginService, LoginValidator validator)
        {
            _loginService = loginService;
            _validator = validator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            
            ValidationResult result = await _validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors); 
            }

            bool isValid = await _loginService.ValidarLoginAsync(request.Cpf, request.Senha);
            if (!isValid)
            {
                return Unauthorized("Login ou senha inválidos."); 
            }

            
            var funcionario = await _loginService.ObterFuncionarioPorCpf(request.Cpf); 
            var paginaAutorizada = await _loginService.ObterPaginaAutorizada(funcionario1.Funcao);

            return Ok(new { Message = "Login bem-sucedido!", PaginaAutorizada = paginaAutorizada }); 
        }
    }
}
