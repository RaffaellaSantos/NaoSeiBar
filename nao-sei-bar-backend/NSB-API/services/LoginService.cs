using Microsoft.EntityFrameworkCore;
using Nao_Sei_Bar_Backend.src.data;

namespace Nao_Sei_Bar_Backend.src.services
{
    public class LoginService(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> ValidarLogin(LoginDto loginDto)
        {            
            var funcionario = await _context.Funcionarios.SingleOrDefaultAsync(f => f.Cpf == loginDto.Cpf);
            if (funcionario == null) return false;
            else
            {
                var funSenha = await _context.Funcionarios.SingleOrDefaultAsync(s => s.Senha == loginDto.Senha);
                if (funSenha == null) return false;
                else
                {
                    return true;
                }
            }
        }

        //public async Task CriarFuncionarioMock()
        //{
        //    var novoFuncionario = new Funcionario
        //    {
        //        Cpf = "595.107.200-03",
        //        Nome = "Funcionário Mockado",
        //        Senha = "mockSenha", 
        //        Funcao = Funcao.Atendente,
        //        Salario = 1500,
        //        Status = true,
        //        DataContratacao = DateTime.Now,
        //        DataNascimento = DateTime.Now.AddYears(-25), 
        //        CargaHorario = 40,
        //        Telefone = "123456789"
        //    };

        //    await _context.Funcionarios.AddAsync(novoFuncionario);

        //    await _context.SaveChangesAsync();
        //}
    }
}
