using Nao_Sei_Bar_Backend.src.data.enums;
using NaoSeiBar.src.data.entities;
using System.Text.Json.Serialization; // Se estiver usando System.Text.Json

namespace NSB_API.data.dtos
{
    public class ProdutoDto
    {
        public string Nome { get; set; }
        public Tipo Tipo { get; set; }
        public double ValorCompra { get; set; }
        public double ValorVenda { get; set; }
        public string Marca { get; set; }
        public int Quantidade { get; set; }
        public DateTime Validade { get; set; }

        [JsonPropertyName("lote")] // Usando a anotação para garantir o mapeamento correto
        public Lote Lote { get; set; }

        [JsonPropertyName("fornecedor")] // Usando a anotação para garantir o mapeamento correto
        public Fornecedor Fornecedor { get; set; }

        public DateTime DataEntrada { get; set; }
    }
}
