using Microsoft.AspNetCore.Mvc;
using Nao_Sei_Bar_Backend.src.data.enums;
using NSB_API.data.dtos;
using NSB_API.services;

namespace NSB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestorController(GestorService gestorService) : Controller
    {
        private readonly GestorService _gestorService = gestorService;

        [HttpPost("CadastrarProduto")]
        [ProducesResponseType(typeof(ProdutoDto), 200)]
        public async Task<IActionResult> CadastrarProduto([FromForm] ProdutoDto produtoDto)
        {
            if (produtoDto == null)
            {
                return BadRequest("ProdutoDto não fornecido.");
            }

            // Verificando se os dados obrigatórios estão presentes
            if (string.IsNullOrEmpty(produtoDto.Nome) || produtoDto.Quantidade <= 0)
            {
                return BadRequest("Nome e Quantidade são obrigatórios.");
            }

            return await _gestorService.CadastrarProduto(produtoDto);
        }

        [HttpGet("ListarProduto/{id}")]
        [ProducesResponseType(typeof(PaginatedResponse<ProdutoDto>), 200)]
        public async Task<IActionResult> ListarProduto(int id)
        {
            var produto = await _gestorService.ListarProdutoPorId(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }
            return Ok(produto);
        }

        [HttpGet("ListarProdutos")]
        [ProducesResponseType(typeof(PaginatedResponse<ProdutoResponseDto>), 200)]
        public async Task<PaginatedResponse<ProdutoResponseDto>> ListarProdutos(
            [FromQuery] PaginationParameters paginationParam,
            [FromQuery] Tipo? filtroTipo = null)
        {
            return await _gestorService.ListarTodosProdutos(paginationParam, filtroTipo);            
        }

        [HttpPut("AlterarProduto/{id}")]
        [ProducesResponseType(typeof(PaginatedResponse<ProdutoResponseDto>), 200)]
        public async Task<IActionResult> AlterarProduto(int id, [FromForm] ProdutoAlterDto produtoDto)
        {
            if (produtoDto == null)
            {
                return BadRequest("ProdutoDto não fornecido.");
            }

            var produtoAtualizado = await _gestorService.AlterarProduto(id, produtoDto);
            if (produtoAtualizado == null)
            {
                return NotFound("Produto não encontrado.");
            }

            return Ok(produtoAtualizado);
        }

        [HttpDelete("DeletarProduto/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            var sucesso = await _gestorService.DeletarProduto(id);
            if (!sucesso)
            {
                return NotFound("Produto não encontrado.");
            }

            return Ok("Produto Deletado"); 
        }
    }
}
