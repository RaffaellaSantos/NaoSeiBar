using Microsoft.EntityFrameworkCore;
using NaoSeiBar.src.data.entities;

namespace Nao_Sei_Bar_Backend.src.data.repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _context;

        public FuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IFuncionario> obterPorCpfAsync(string cpf)
        {
            var atendente = await _context.Set<Atendente>().FirstOrDefaultAsync(a => a.Cpf == cpf);
            if (atendente == null) return null;

            var rh = await _context.Set<RH>().FirstOrDefaultAsync(a => a.Cpf == cpf);
            if (atendente == null) return null;

            var financeiro = await _context.Set<Financeiro>().FirstOrDefaultAsync(a => a.Cpf == cpf);
            if (atendente == null) return null;

            //var gestorDeEstoque = await _context.Set<Atendente>().FirstOrDefaultAsync(a => a.Cpf == cpf);
            //if (atendente == null) return null;

            return null;
        }
    }
}
