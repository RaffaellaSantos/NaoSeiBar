using Microsoft.AspNetCore.Http.HttpResults;
using Nao_Sei_Bar_Backend.src.data.enums;
using Nao_Sei_Bar_Backend.src.data.repository;
using Nao_Sei_Bar_Backend.src.services.interfaces;
using NaoSeiBar.src.data.entities;

namespace Nao_Sei_Bar_Backend.src.services
{
    public class LoginService(IFuncionarioRepository funcionarioRepository) : ILogin
    {
        private readonly IFuncionarioRepository _funcionarioRepository = funcionarioRepository;

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

        public string ObterPaginaAutorizada(Funcao funcao)
        {
            switch (funcao)
            {
                case Funcao.Atendente:
                    return "/pagina-atendente";
            }
            return null;
        }

        Task<bool> ILogin.ObterFuncionarioPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        Task<bool> ILogin.ValidarLoginAsync(string cpf, string senha)
        {
            throw new NotImplementedException();
        }

        Task<string> ILogin.ObterPaginaAutorizada(Funcao funcao)
        {
            throw new NotImplementedException();
        }
    }
}
