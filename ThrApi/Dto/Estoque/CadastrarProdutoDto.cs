using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ThrApi.Models.Estoque;

namespace ThrApi.Dto.Estoque
{
    public class CadastrarProdutoDto
    {
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

        public CadastrarProdutoDto() { }

        public CadastrarProdutoDto(ProdutosModel model)
        {
            this.codigo = model.Codigo;
            this.descricao = model.Descricao;
            this.unidade = model.Unidade;
            this.fornecedor = model.Fornecedor;
            this.categoriaA = model.CategoriaA;
            this.categoriaB = model.CategoriaB;
            this.categoriaC = model.CategoriaC;
            this.quantidadeEstoque = model.QuantidadeEstoque;
            this.estoqueMinimo = model.EstoqueMinimo;
            this.estoqueMaximo = model.EstoqueMaximo;
            this.estoqueSeguranca = model.EstoqueSeguranca;
            this.usuarioCadastro = model.UsuarioCadastro;
        }

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
    }
}
