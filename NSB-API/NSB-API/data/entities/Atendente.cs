using Microsoft.EntityFrameworkCore;
using Nao_Sei_Bar_Backend.src.data.enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NaoSeiBar.src.data.entities
{
    public class Atendente : IFuncionario
    {
        [Key]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Funcao Funcao { get; set; }
        public double Salario { get; set; }
        public bool Status { get; set; }
        public DateTime DataContratacao { get; set; }
        public int CargaHorario { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        string IFuncionario.Cpf { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IFuncionario.Nome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime IFuncionario.DataNascimento { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Funcao IFuncionario.Funcao { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double IFuncionario.Salario { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        bool IFuncionario.Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime IFuncionario.DataContratacao { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IFuncionario.CargaHorario { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IFuncionario.Telefone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IFuncionario.Senha { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Atendente(string cpf, string nome, DateTime dataNascimento, Funcao funcao, double salario, bool status, DateTime dataContratacao, int cargaHorario, string telefone, string senha)
        {
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Funcao = funcao;
            Salario = salario;
            Status = true;
            DataContratacao = dataContratacao;
            CargaHorario = cargaHorario;
            Telefone = telefone;
            Senha = senha;
        }

        bool IFuncionario.VerificarCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        bool IFuncionario.ValidarSenha(string senha)
        {
            throw new NotImplementedException();
        }
    }
}
