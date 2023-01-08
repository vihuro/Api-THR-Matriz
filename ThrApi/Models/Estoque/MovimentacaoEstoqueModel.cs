namespace ThrApi.Models.Estoque
{
    public class MovimentacaoEstoqueModel
    {
        private Guid id;
        private string codigoMaterial;
        private string descricaoMaterial;
        private string unidade;
        private string tipoMovimentacao;
        private decimal quantidadeMovimentada;
        private string nomeUsuarioMovimentacao;
        private DateTime dataHoraMovimentacao;

        public Guid Id { get => id; set => id = value; }
        public string CodigoMaterial { get => codigoMaterial; set => codigoMaterial = value; }
        public string DescricaoMaterial { get => descricaoMaterial; set => descricaoMaterial = value; }
        public string Unidade { get => unidade; set => unidade = value; }
        public string TipoMovimentacao { get => tipoMovimentacao; set => tipoMovimentacao = value; }
        public decimal QuantidadeMovimentada { get => quantidadeMovimentada; set => quantidadeMovimentada = value; }
        public string NomeUsuarioMovimentacao { get => nomeUsuarioMovimentacao; set => nomeUsuarioMovimentacao = value; }
        public DateTime DataHoraMovimentacao { get => dataHoraMovimentacao; set => dataHoraMovimentacao = value; }
    }
}
