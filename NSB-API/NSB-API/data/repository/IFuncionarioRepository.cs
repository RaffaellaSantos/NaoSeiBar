using NaoSeiBar.src.data.entities;

namespace Nao_Sei_Bar_Backend.src.data.repository
{
    public interface IFuncionarioRepository
    {
        Task<IFuncionario> obterPorCpfAsync(string cpf);
    }
}
