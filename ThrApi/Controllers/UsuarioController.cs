using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ThrApi.Context;
using ThrApi.Models;
using ThrApi.Service.JWT;

namespace ThrApi.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioContext context;
        public UsuarioController(UsuarioContext context)
        {
            this.context = context;
        }

        [ClaimsAuthorizeAttibute("Produto", "User")]
        [HttpGet]
        public IActionResult OlaDotNet()
        {
            return Ok("aqui, tem todos os segredos da empresa hahahahahahahaha");
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> logar([FromBody]UsuarioModel model)
        {


            UsuarioModel obj = new UsuarioModel();
            var usuario = context.Usuario.Where(x => x.Apelido == model.Apelido && x.Senha == model.Senha);

            if(usuario.Count() == 0)
            {
                return BadRequest();
            }
            obj.Apelido = model.Apelido;
            
            return Ok(CreateToken(model));


            /*usuario = context.Usuario.Select(x => x.Apelido == Apelido);
            if(usuario != null)
            {
                usuario = context.Usuario.Select(x => x.Senha == senha);
                if(usuario != null)
                {
                    model.Apelido = Apelido;

                    return Ok(CreateToken(model));
                }
                return BadRequest();
            }
            return BadRequest();*/
            

            //Console.WriteLine(usuario);


            //if(usuario.)

            //if(context.Usuario.Find(model.NomeUsuario))
        }

        [HttpPost("create-user")]
        public string Cadastrar(string usuario, string apelido, string senha)
        {
            UsuarioModel model = new UsuarioModel();
            model.NomeUsuario = usuario;
            model.Apelido = apelido;
            model.Senha = senha;
            context.Usuario.Add(model);
            context.SaveChanges();
            return "Cadastro realizado com sucesso";
        }

        private string CreateToken(UsuarioModel model)
        {

            var tokenHeader = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ajlKjLASJUISHIUO@2423");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("","admin")
                    
                    //new Claim(ClaimTypes.Name, model.Apelido),
                    //new Claim(ClaimTypes.Role,"Admin,User,Expedicao,Estoque"),

                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHeader.CreateToken(tokenDescriptor);
            return tokenHeader.WriteToken(token);

            /* Jeito antigo
            string [] Roles = new string []
            {
                "Usuario",
                "Admin"
            };

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,model.Apelido),

                new Claim(ClaimTypes.Role,"Admin,User")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("JKLJnsklnlaKAK!@#nkl456"));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(

                claims: claims,

                expires: DateTime.Now.AddHours(8),
                signingCredentials: cred
                );*/

            // var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            //return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
