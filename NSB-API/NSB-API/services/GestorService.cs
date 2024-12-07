using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nao_Sei_Bar_Backend.src.data;
using Nao_Sei_Bar_Backend.src.data.entities;
using NaoSeiBar.src.data.entities;
using NSB_API.data.dtos;

namespace NSB_API.services
{
    public class GestorService(AppDbContext context)
    {
        private readonly AppDbContext _context = context;
        public async Task<IActionResult> CadastrarProduto(ProdutoDto produtoDto)
        {

            if (produtoDto == null)
            {
                return new BadRequestObjectResult("Dados do produto não fornecidos.");
            }

            var produto = new Produto
            {
                Nome = produtoDto.Nome,
                Tipo = produtoDto.Tipo,
                ValorCompra = produtoDto.ValorCompra,
                ValorVenda = produtoDto.ValorVenda,
                Marca = produtoDto.Marca,
                Quantidade = produtoDto.Quantidade,
                Validade = produtoDto.Validade,
                Lote = produtoDto.Lote, //deve ser mockado
                Fornecedor = produtoDto.Fornecedor, //deve ser mockado
                DataEntrada = DateTime.Now
            };

            produto.Lote = new Lote
            {
                DataFornecimento = DateTime.Now, // Simulando a data de fornecimento
                Descricao = "Lote Mockado",      // Exemplo de descrição
                ValorTotal = 100.0,              // Valor mockado para o lote
                Fornecedor = new Fornecedor     // Mockando o fornecedor
                {
                    Cnpj = "00.000.000/0001-00",  // CNPJ mockado
                    Nome = "Fornecedor Mockado",
                    Banco = "Banco Mockado",
                    NumeroConta = "12345",
                    Agencia = "001",
                    StatusFornecedor = true,
                    DataContratacao = DateTime.Now,
                    Telefone = "999999999",
                    Email = "fornecedor@mock.com"
                }
            };

            produto.Fornecedor = produto.Lote.Fornecedor;

            _context.Add(produto);

            await _context.SaveChangesAsync();

            return new OkObjectResult(produto);
        }

        public async Task<Produto> ListarProdutoPorId(int id)
        {
            return await _context.Produtos
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Produto>> ListarTodosProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> AlterarProduto(int id, ProdutoDto produtoDto)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return null;

            produto.Nome = produtoDto.Nome ?? produto.Nome;
            produto.Tipo = produtoDto.Tipo;
            produto.ValorCompra = produtoDto.ValorCompra > 0 ? produtoDto.ValorCompra : produto.ValorCompra;
            produto.ValorVenda = produtoDto.ValorVenda > 0 ? produtoDto.ValorVenda : produto.ValorVenda;
            produto.Marca = produtoDto.Marca ?? produto.Marca;
            produto.Quantidade = produtoDto.Quantidade > 0 ? produtoDto.Quantidade : produto.Quantidade;
            produto.Validade = produtoDto.Validade;

            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<bool> DeletarProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return false;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
