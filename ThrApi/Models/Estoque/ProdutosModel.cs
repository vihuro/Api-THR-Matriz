using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ThrApi.Models.Estoque
{
    [Table ("tab_Produtos")]
    public class ProdutosModel
    {
        private Guid id;
        [Required]
        private string codigo;
        [Required]
        private string descricao;
        [Required]
        private string unidade;
        [Required]
        private string fornecedor;
        [Required]
        private string categoriaA;
        [AllowNull]
        private string categoriaB;
        [AllowNull]
        private string categoriaC;
        [Required]
        private decimal quantidadeEstoque;
        [Required]
        private decimal estoqueSeguranca;
        [Required]
        private decimal estoqueMinimo;
        [Required]
        private decimal estoqueMaximo;
        [Required]
        private string usuarioCadastro;
        [Required]
        private DateTime dataHoraCadastro;
        [Required]
        private string usuarioAlteracao;
        [Required]
        private DateTime dataHoraAlteracao;

        public Guid Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Unidade { get => unidade; set => unidade = value; }
        public string Fornecedor { get => fornecedor; set => fornecedor = value; }
        public string CategoriaA { get => categoriaA; set => categoriaA = value; }
        [AllowNull]
        public string? CategoriaB { get => categoriaB; set => categoriaB = value; }
        [AllowNull]
        public string? CategoriaC { get => categoriaC; set => categoriaC = value; }
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
