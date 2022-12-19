using ThrApi.Models.Estoque;

namespace ThrApi.Dto.Estoque
{
    public class ProdutoEstoqueDto
    {
        private Guid id;
        private string codigo;
        private string descricao;
        private string unidade;
        private string fornecedor;
        private string categoriaA;
        private string categoriaB;
        private string categoriaC;
        private decimal quantidadeEstoque;
        private decimal estoqueSeguranca;
        private decimal estoqueMinimo;
        private decimal estoqueMaximo;
        private string usuarioCadastro;
        private DateTime dataHoraCadastro;
        private string usuarioAlteracao;
        private DateTime dataHoraAlteracao;

        public ProdutoEstoqueDto() { }
        public ProdutoEstoqueDto(ProdutosModel model)
        {
            this.id = model.Id;
            this.codigo = model.Codigo;
            this.descricao= model.Descricao;
            this.unidade = model.Unidade;
            this.fornecedor = model.Fornecedor;
            this.categoriaA = model.CategoriaA;
            this.categoriaB = model.CategoriaB;
            this.categoriaC = model.CategoriaC;
            this.quantidadeEstoque= model.QuantidadeEstoque;
            this.estoqueSeguranca = model.EstoqueSeguranca;
            this.estoqueMinimo = model.EstoqueMinimo;
            this.estoqueMaximo = model.EstoqueMaximo;
            this.usuarioCadastro = model.UsuarioCadastro;
            this.dataHoraCadastro = model.DataHoraCadastro;
            this.usuarioAlteracao = model.UsuarioAlteracao;
            this.dataHoraAlteracao = model.DataHoraAlteracao;
        }

        public Guid Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Unidade { get => unidade; set => unidade = value; }
        public string Fornecedor { get => fornecedor; set => fornecedor = value; }
        public string CategoriaA { get => categoriaA; set => categoriaA = value; }
        public string CategoriaB { get => categoriaB; set => categoriaB = value; }
        public string CategoriaC { get => categoriaC; set => categoriaC = value; }
        public decimal QuantidadeEstoque { get => quantidadeEstoque; set => quantidadeEstoque = value; }
        public decimal EstoqueSeguranca { get => estoqueSeguranca; set => estoqueSeguranca = value; }
        public decimal EstoqueMinimo { get => estoqueMinimo; set => estoqueMinimo = value; }
        public decimal EstoqueMaximo { get => estoqueMaximo; set => estoqueMaximo = value; }
        public string UsuarioCadastro { get => usuarioCadastro; set => usuarioCadastro = value; }
        public DateTime DataHoraCadastro { get => dataHoraCadastro; set => dataHoraCadastro = value; }
        public string UsuarioAlteracao { get => usuarioAlteracao; set => usuarioAlteracao = value; }
        public DateTime DataHoraAlteracao { get => dataHoraAlteracao; set => dataHoraAlteracao = value; }
    }
}
