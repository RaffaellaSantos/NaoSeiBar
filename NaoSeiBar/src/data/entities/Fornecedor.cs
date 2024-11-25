using System.Globalization;
using System.Net.Http.Headers;

namespace NaoSeiBar.src.data.entities
{
    public class Fornecedor
    {
        private string cnpj {  get; set; }
        private string nome { get; set; }
        private Produto produto { get; set; }
        private string banco {  get; set; }
        private string numeroConta {  get; set; }
        private string agencia { get; set; }
        private bool statusFornecedor { get; set; }
        private DateTime dataContratacao { get; set; }
        private string telefone { get; set; }
        private string email { get; set; }
    }
}
