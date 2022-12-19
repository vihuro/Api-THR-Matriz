using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ThrApi.Interface.Login;
using ThrApi.Models.Login;

namespace ThrApi.Service.JWT
{
    public class CreateToken : ICreateToken
    {
        private readonly IClaims claims;
        public CreateToken(IClaims claims)
        {
            this.claims = claims;
        }
        public string Create(UsuarioModel user)
        {
            var tokenHeader = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ajlKjLASJUISHIUO@2423");


            var tokenDescriptor = new SecurityTokenDescriptor();

            var listClaimns = claims.ClaimsUser(user.Id);
            var claim = new List<Claim>();

            for (int i = 0; i < listClaimns.Count; i++)
            {

                claim.Add(new Claim(listClaimns[i].ClaimName, listClaimns[i].ClaimValue));


            }

            tokenDescriptor.Subject = new ClaimsIdentity(claim);

            //foreach (var itens in listClaimns)
            //{

            //    tokenDescriptor.Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(itens.ClaimName, itens.ClaimValue),
            //        new Claim("Teste3", "Teste4")
            //    });


            //};
            tokenDescriptor.Expires = DateTime.UtcNow.AddHours(8);
            tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            tokenDescriptor.Issuer = user.NomeUsuario;



     


       
        
            //foreach (var itens in listClaimns)
            //{
            //    tokenDescriptor.Claims.Add(itens.ClaimName, itens.ClaimValue);

            //    //tokenDescriptor.Subject = new ClaimsIdentity(new Claim[]
            //    //{
            //    //     tokenDescriptor.Claims.Add(itens.ClaimName, itens.ClaimValue)
            //    //});

            //}

   

            //tokenDescriptor.Expires = DateTime.UtcNow.AddHours(8);
            //tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);


            //var tokenDescriptor = new SecurityTokenDescriptor
            //{



            //    //Subject = new ClaimsIdentity(new Claim[]
            //    //{
            //    //    new Claim(ClaimTypes.NameIdentifier, user.NomeUsuario),
            //    //    new Claim("Produto","Admin")

            //    //    //new Claim(ClaimTypes.Name, model.Apelido),
            //    //    //new Claim(ClaimTypes.Role,"Admin,User,Expedicao,Estoque"),

            //    //}),
            //    Expires = DateTime.UtcNow.AddHours(8),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};

            var token = tokenHeader.CreateToken(tokenDescriptor);

            return tokenHeader.WriteToken(token);
        }
    }
}
