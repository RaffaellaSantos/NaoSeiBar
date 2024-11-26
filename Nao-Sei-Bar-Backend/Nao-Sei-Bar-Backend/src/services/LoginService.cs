using Nao_Sei_Bar_Backend.src.data.enums;
using Nao_Sei_Bar_Backend.src.data.repository;
using Nao_Sei_Bar_Backend.src.services.interfaces;
using NaoSeiBar.src.data.entities;

namespace Nao_Sei_Bar_Backend.src.services
{
    public class LoginService : ILogin
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public LoginService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<bool> ValidarLoginAsync(string cpf, string senha)
        {
            var funcionario = await _funcionarioRepository.obterPorCpfAsync(cpf);
            if (funcionario == null)
            {
                return false; 
            }

            return funcionario.ValidarSenha(senha); 
        }

        public async Task<IFuncionario> ObterFuncionarioPorCpf(string cpf)
        {
            var funcionario = await _funcionarioRepository.obterPorCpfAsync(cpf);
            return funcionario; // Retorna o funcionário encontrado
        }

        public async Task<string> ObterPaginaAutorizada(Funcao funcao)
        {
            switch (funcao)
            {
                case Funcao.Atendente:
                    return "/pagina-atendente";
            }
        }
    }
}
