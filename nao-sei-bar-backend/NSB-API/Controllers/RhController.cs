using Microsoft.AspNetCore.Mvc;
using NSB_API.data.dtos;
using NSB_API.services;

namespace NSB_API.Controllers
{
    public class RhController(RhService rhService) : Controller
    {
        private readonly RhService _rhService = rhService;

        [HttpPost("CadastrarFuncionario")]
        [ProducesResponseType(typeof(FuncionarioDto), 200)]
        public async Task<IActionResult> CadastrarFuncionario([FromForm] FuncionarioDto funcionarioDto)
        {
            if(funcionarioDto == null)
            {
                return BadRequest("Entrada inválida");
            }

            return await _rhService.CadastrarFuncionario(funcionarioDto);
        }

        [HttpGet("ListarFuncionarioPorCpf")]
        public async Task<IActionResult> ListarFuncionario(string cpf)
        {
            var funcionario = await _rhService.ListarFuncionarioPorCpf(cpf);
            if(funcionario == null)
            {
                return BadRequest("Funcionario não encontrado");
            }
            return Ok(funcionario);
        }
    }
}
