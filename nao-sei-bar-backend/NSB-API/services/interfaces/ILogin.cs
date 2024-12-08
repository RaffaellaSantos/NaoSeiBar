using Nao_Sei_Bar_Backend.src.data.enums;

namespace Nao_Sei_Bar_Backend.src.services.interfaces
{
    public interface ILogin
    {
        Task<bool> ValidarLoginAsync(string cpf, string senha);
        Task<bool> ObterFuncionarioPorCpf(string cpf);
        Task<string> ObterPaginaAutorizada(Funcao funcao);
    }
}
