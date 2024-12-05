using Nao_Sei_Bar_Backend.src.data.entities;

namespace NaoSeiBar.src.data.entities
{
    public class Comanda
    {
        private int id { get; }
        private string nomeVendedor { get; set; }
        private DateTime dataCompra { get; set; }
        private DateTime horarioCompra { get; set; }
        private Produto produto { get; set; }
        private int quantidade { get; set; }
        private double valorVenda { get; set; }
        private Cliente cliente { get; set; }
    }
}
