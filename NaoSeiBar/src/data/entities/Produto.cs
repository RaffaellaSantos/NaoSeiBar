namespace NaoSeiBar.src.data.entities
{
    public class Produto
    {
        private int id { get; }
        private string nome { get; set; }
        private Tipo tipo { get; set; }
        private double valorCompra {  get; set; }
        private double valorVenda { get; set; }
        private string marca { get; set; }
        private int quantidade { get; set; }
        private DateTime validade { get; set; }
        private Lote lote { get; set; }
        private Fornecedor forncedor { get; set; }
        private DateTime dataEntrada { get; set; }
    }
}
