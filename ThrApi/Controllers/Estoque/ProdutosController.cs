using Microsoft.AspNetCore.Mvc;
using ThrApi.Dto.Estoque;
using ThrApi.Interface.Estoque;

namespace ThrApi.Controllers.Estoque
{
    [ApiController]
    [Route("api/estoque")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosService produtoService;
        public ProdutosController(IProdutosService produtoService) 
        {
            this.produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult BuscarTodosProdutos()
        {

            try
            {
                return Ok(produtoService.ObterProdutosEstoque());
            }
            catch (Exception ex)
            {

                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CadastrarNovoProduto([FromBody]CadastrarProdutoDto dto)
        {
            try
            {
                var cadatro = produtoService.CadastrarProduto(dto);
                return Ok(cadatro);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult DeletarTodosProdutos()
        {
            try
            {
                produtoService.DeletarTodosProdutos();

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
