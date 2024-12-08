using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nao_Sei_Bar_Backend.src.data;
using NSB_API.data.dtos;
using NSB_API.data.entities;

namespace NSB_API.services
{
    public class RhService(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<IActionResult> CadastrarFuncionario(FuncionarioDto funcionarioDto)
        {
            if (funcionarioDto == null)
            {
                return new BadRequestObjectResult("Dados do funcionário não fornecidos");
            }

            var senha = GerarSenha();

            var funcionario = new Funcionario
            {
                Cpf = funcionarioDto.Cpf,
                Nome = funcionarioDto.Nome,
                DataNascimento = funcionarioDto.DataNascimento,
                Funcao = funcionarioDto.Funcao,
                Salario = funcionarioDto.Salario,
                Status = funcionarioDto.Status,
                DataContratacao = funcionarioDto.DataContratacao,
                CargaHorario = funcionarioDto.CargaHorario,
                Telefone = funcionarioDto.Telefone,
                Senha = senha
            };

            await _context.AddAsync(funcionario);

            await _context.SaveChangesAsync();

            return new OkObjectResult(funcionario);
        }

        private string GerarSenha()
        {
            Random random = new Random();

            string senha = random.Next(10000000, 99999999).ToString();

            return senha;
        }

        public async Task<Funcionario> ListarFuncionarioPorCpf(string cpf)
        {
            return await _context.Funcionarios.SingleOrDefaultAsync(f => f.Cpf == cpf);
        }
    }
}
