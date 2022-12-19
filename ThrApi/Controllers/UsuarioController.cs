using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ThrApi.Context;
using ThrApi.Models;
using ThrApi.Models.Login;
using ThrApi.Service.JWT;
using BCrypt.Net;
using ThrApi.Interface.Login;
using ThrApi.Dto.Login;
using ThrApi.Service.CustonException;

namespace ThrApi.Controllers
{

    [ApiController]
    [Route("api/login")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioContext context;
        private readonly ILogin login;
        public UsuarioController(ILogin login)
        {
            this.login = login;
        }

        [HttpPost("create-user")]
        public IActionResult Create(LoginCreateDto dto)
        {
            try
            {
                var newUser = login.Create(dto);



                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [ClaimsAuthorizeAttibute("Produto", "Admin")]
        [HttpGet]
        public IActionResult OlaDotNet()
        {
            return Ok("aqui, tem todos os segredos da empresa hahahahahahahaha");
        }
        [HttpDelete("Delete-All")]
        public async Task<ActionResult<string>> DeleteAll()
        {
            try
            {
                login.DeleteAll();

                return Ok("Usuários deletados com sucesso!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<LoginUserDto> logar([FromBody] LoginDto dto)
        {
            try
            {
                var Token = login.Logar(dto);

                return Token;
            }
            catch (ExceptionService ex)
            {

                return UnprocessableEntity(ex.Message);
            }

        }

        [HttpGet("SelecUserAll")]
        public IEnumerable<object> SelectAll()
        {

            var list = login.SelectAll();
            return list;

        }

    }
}
