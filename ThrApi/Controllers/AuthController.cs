using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ThrApi.Models;

namespace ThrApi.Controllers
{
   // [Route("api/[controller]")]
   // [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser>  _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(UsuarioModel model)
        {
            UsuarioModel obj = new UsuarioModel();
            obj.NomeUsuario = model.NomeUsuario;
            obj.Apelido = model.Apelido;
            obj.Senha = model.Senha;

            

            return Ok(model);
        }

        private string CreateToken(UsuarioModel model)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,model.NomeUsuario)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("JKLJnsklnlaKAK!@#nkl456"));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials:cred
                );

           // var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
