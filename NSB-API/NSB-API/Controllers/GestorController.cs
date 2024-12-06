using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NaoSeiBar.src.data.entities;
using NSB_API.data.dtos;

namespace NSB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestorController(IFuncionario funcionario, DbContext context) : Controller
    {
        readonly IFuncionario _funcionario = funcionario;
        readonly DbContext _context = context;

        [HttpPost("CadastrarProduto")]
        public async Task<IActionResult> CadastrarProduto([FromBody] ProdutoDto produtoDto)
        {
            
        }

        [HttpGet("ListarPrdotuo/[id]")]

        [HttpGet("ListarProdutos")]

        [HttpPut("AlterarProduto/[id]")]

        [HttpDelete("DeletarProduto/[id]")]


    }
}
