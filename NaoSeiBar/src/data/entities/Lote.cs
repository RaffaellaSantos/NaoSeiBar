namespace NaoSeiBar.src.data.entities
{
    public class Lote
    {
        private int id;
        private DateTime dataFornecimento {  get; set; }
        private string descricao {  get; set; }
        private double valorTotal {  get; set; }
        private Fornecedor forncecedor { get; set; }
    }
}
