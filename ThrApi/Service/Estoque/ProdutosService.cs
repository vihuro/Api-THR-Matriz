using ThrApi.Context;
using ThrApi.Dto.Estoque;
using ThrApi.Interface.Estoque;
using ThrApi.Models.Estoque;
using ThrApi.Service.CustonException;

namespace ThrApi.Service.Estoque
{
    public class ProdutosService : IProdutosService
    {
        private readonly UsuarioContext context;
        private ProdutosModel model;

        public ProdutosService(UsuarioContext context)
        {
            this.context = context;
        }

        public ProdutosModel AlterarProduto(ProdutoEstoqueDto dto)
        {
            throw new NotImplementedException();
        }

        public ProdutoEstoqueDto BuscarPorCodigo(string codigo)
        {
            var obj = context.Produtos.FirstOrDefault(x => x.Codigo == codigo);
            if(obj == null)
            {
                return null;
            }

            return new ProdutoEstoqueDto(obj);
        }

        public ProdutosModel BuscarPorID(Guid id)
        {
            var obj = context.Produtos.Find(id);
            if(obj == null)
            {
                return null;
            }
            return obj;
        }

        public NovoProdutoDto CadastrarProduto(CadastrarProdutoDto dto)
        {
            var obj = BuscarPorCodigo(dto.Codigo);
            if(obj != null)
            {
                throw new ExceptionService("Código já cadastrado!");
            }
            if (!ValidarEstoque(dto.EstoqueMinimo, dto.EstoqueMaximo, dto.EstoqueSeguranca))
            {
                throw new ExceptionService("Erro ao valídar estoque maxímo, mínimo e estoque de segurança!");
            }
            model = new ProdutosModel();
            model.Codigo = dto.Codigo;
            model.Descricao = dto.Descricao;
            model.Fornecedor = dto.Fornecedor;
            model.CategoriaA = dto.CategoriaA;
            model.CategoriaB = dto.CategoriaB;
            model.CategoriaC = dto.CategoriaC;
            model.EstoqueMaximo = dto.EstoqueMaximo;
            model.EstoqueMinimo = dto.EstoqueMinimo;
            model.Unidade = dto.Unidade;
            model.EstoqueSeguranca = dto.EstoqueSeguranca;
            model.UsuarioCadastro = dto.UsuarioCadastro;
            model.DataHoraCadastro = DateTime.UtcNow;
            model.UsuarioAlteracao = dto.UsuarioCadastro;
            model.DataHoraAlteracao = DateTime.UtcNow;

            context.Produtos.Add(model);
            context.SaveChanges();

            return new NovoProdutoDto(model);
            
        }

        public bool ValidarEstoque(decimal estoqueMinimo, decimal estoqueMaximo, decimal estoqueSeguranca)
        {
            if(estoqueMinimo > estoqueMaximo)
            {
                return false;
            }
            if(estoqueSeguranca > estoqueMaximo)
            {
                return false;
            }
            if(estoqueMinimo < 0)
            {
                return false;
            }

            return true;

        }

        public ProdutosModel DeletarProduto(Guid id)
        {
            var obj = BuscarPorID(id);
            if (id == null)
            {
                throw new ExceptionService("Produto não cadastrado!");
            }

            context.Produtos.Remove(obj);
            context.SaveChanges();

            return obj;
        }

        public void DeletarTodosProdutos()
        {
            var list = ObterProdutosEstoque();
            foreach (var obj in list)
            {
                context.Produtos.Remove(obj);
                context.SaveChanges();
            }
        }
        public List<ProdutosModel> ObterProdutosEstoque()
        {
            return context.Produtos.ToList();
        }

    }
}
