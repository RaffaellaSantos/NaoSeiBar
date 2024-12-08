using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nao_Sei_Bar_Backend.src.data;
using Nao_Sei_Bar_Backend.src.data.entities;
using Nao_Sei_Bar_Backend.src.data.enums;
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

            string cnpj = GerarCnpjAleatorio();

            var produto = new Produto
            {
                Nome = produtoDto.Nome,
                Tipo = produtoDto.Tipo,
                ValorVenda = produtoDto.ValorVenda,
                Marca = produtoDto.Marca,
                Quantidade = produtoDto.Quantidade,
                Validade = produtoDto.Validade,
                Lote = new Lote
                {
                    DataFornecimento = DateTime.Now,
                    Descricao = "Lote Mockado",
                    ValorTotal = 100.0,
                    Fornecedor = new Fornecedor 
                    {
                        Cnpj = cnpj, 
                        Nome = "Fornecedor Mockado",
                        Banco = "Banco Mockado",
                        NumeroConta = "12345",
                        Agencia = "001",
                        StatusFornecedor = true,
                        DataContratacao = DateTime.Now,
                        Telefone = "999999999",
                        Email = "fornecedor@mock.com"
                    }
                },
                DataEntrada = DateTime.Now
            };

            _context.Add(produto);

            await _context.SaveChangesAsync();

            return new OkObjectResult(produto);
        }

        private string GerarCnpjAleatorio()
        {
            Random random = new Random();

            // Gera os 8 primeiros dígitos aleatórios (não é necessário fixar a parte "/0001")
            string numeroCnpj = random.Next(10000000, 99999999).ToString();  // 8 dígitos aleatórios

            // Gerar o CNPJ completo com o "/0001-" fixo
            string cnpjBase = numeroCnpj + "0001";  // Parte fixa "/0001"

            // Gerar os dois últimos dígitos verificadores
            string cnpjCompleto = cnpjBase + GerarDigitosVerificadores(cnpjBase);

            // Formatar para o formato desejado: XX.XXX.XXX/XXXX-XX
            string cnpjFormatado = $"{cnpjCompleto.Substring(0, 2)}.{cnpjCompleto.Substring(2, 3)}.{cnpjCompleto.Substring(5, 3)}/{cnpjCompleto.Substring(8, 4)}-{cnpjCompleto.Substring(12, 2)}";

            return cnpjFormatado;
        }

        private string GerarDigitosVerificadores(string cnpjBase)
        {
            int[] multiplicadoresPrimeiroDigito = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadoresSegundoDigito = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Primeiro dígito verificador
            int primeiroDigito = CalcularDigitoVerificador(cnpjBase, multiplicadoresPrimeiroDigito);

            // Segundo dígito verificador
            int segundoDigito = CalcularDigitoVerificador(cnpjBase + primeiroDigito, multiplicadoresSegundoDigito);

            return primeiroDigito.ToString() + segundoDigito.ToString();
        }

        private int CalcularDigitoVerificador(string cnpj, int[] multiplicadores)
        {
            int soma = 0;
            for (int i = 0; i < multiplicadores.Length; i++)
            {
                soma += int.Parse(cnpj[i].ToString()) * multiplicadores[i];
            }

            int resto = soma % 11;
            return (resto < 2) ? 0 : 11 - resto;
        }

        public async Task<Produto> ListarProdutoPorId(int id)
        {
            return await _context.Produtos.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PaginatedResponse<ProdutoResponseDto>> ListarTodosProdutos(
            PaginationParameters paginationParam,
            Tipo? filtroTipo = null)
        {
            var query = _context.Produtos.AsQueryable();

            if (filtroTipo.HasValue)
            {
                query = query.Where(p => p.Tipo == filtroTipo.Value);
            }

            var totalItems = await query.CountAsync();

            var items = await query
                .Skip(paginationParam.GetSkip())
                .Take(paginationParam.GetTake())
                .Select(r => new ProdutoResponseDto
                {
                    Id = r.Id,
                    Nome = r.Nome,
                    Tipo = r.Tipo,
                    ValorCompra = r.ValorCompra,
                    ValorVenda = r.ValorVenda,
                    Marca = r.Marca,
                    Quantidade = r.Quantidade,
                    Validade = r.Validade,
                    Lote = r.Lote,
                    DataEntrada = r.DataEntrada
                })
                .ToListAsync();

            return new PaginatedResponse<ProdutoResponseDto>
            {
                PageNumber = paginationParam.PageNumber,
                PageSize = paginationParam.PageSize,
                CurrentPage = totalItems,
                Items = items
            };
        }

        public async Task<ProdutoResponseDto> AlterarProduto(int id, ProdutoAlterDto produtoDto)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return null;

            if (!string.IsNullOrEmpty(produtoDto.Nome)) produto.Nome = produtoDto.Nome;
            if (produtoDto.Tipo.HasValue) produto.Tipo = produtoDto.Tipo.Value;
            if (produtoDto.ValorVenda.HasValue && produtoDto.ValorVenda > 0) produto.ValorVenda = produtoDto.ValorVenda.Value;
            if (!string.IsNullOrEmpty(produtoDto.Marca)) produto.Marca = produtoDto.Marca;
            if (produtoDto.Quantidade.HasValue && produtoDto.Quantidade > 0) produto.Quantidade = produtoDto.Quantidade.Value;
            if (produtoDto.Validade.HasValue) produto.Validade = produtoDto.Validade.Value;

            await _context.SaveChangesAsync();

            return new ProdutoResponseDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Tipo = produto.Tipo,
                ValorCompra = produto.ValorCompra,
                ValorVenda = produto.ValorVenda,
                Marca = produto.Marca,
                Quantidade = produto.Quantidade,
                Validade = produto.Validade,
                Lote = produto.Lote,
                DataEntrada = produto.DataEntrada
            };
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
