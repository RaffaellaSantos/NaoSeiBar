using Nao_Sei_Bar_Backend.src.data.enums;
using NaoSeiBar.src.data.entities;

namespace NSB_API.data.dtos
{
    public class ProdutoResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Tipo Tipo { get; set; }
        public double ValorCompra { get; set; }
        public double ValorVenda { get; set; }
        public string Marca { get; set; }
        public int Quantidade { get; set; }
        public DateTime Validade { get; set; }
        public Lote Lote { get; set; }
        public DateTime DataEntrada { get; set; }
    }
}
