using ThrApi.Dto.Estoque;
using ThrApi.Models.Estoque;

namespace ThrApi.Interface.Estoque
{
    public interface IProdutosService
    {
        List<ProdutosModel> ObterProdutosEstoque();
        NovoProdutoDto CadastrarProduto(CadastrarProdutoDto dto);
        ProdutosModel DeletarProduto(Guid id);
        ProdutosModel AlterarProduto(ProdutoEstoqueDto dto);
        ProdutosModel BuscarPorID(Guid id);
        ProdutoEstoqueDto BuscarPorCodigo(string codigo);

        bool ValidarEstoque(decimal estoqueMinimo, decimal estoqueMaximo, decimal estoqueSeguranca);

        void DeletarTodosProdutos();
    }
}
