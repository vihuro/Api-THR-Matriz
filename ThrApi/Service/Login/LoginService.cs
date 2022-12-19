using ThrApi.Dto.Login;
using ThrApi.Models.Login;
using ThrApi.Context;
using BCrypt.Net;
using ThrApi.Interface.Login;
using ThrApi.Service.CustonException;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using ThrApi.Service.JWT;

namespace ThrApi.Service.Login
{
    public class LoginService : ILogin
    {
        private readonly UsuarioContext context;
        private readonly IClaims claimsService;
        private readonly ICreateToken createToken;
        public LoginService(UsuarioContext context, IClaims claimsService, ICreateToken createToken)
        {
            this.context = context;
            this.claimsService = claimsService;
            this.createToken = createToken;
        }

        public LoginUserDto Logar(LoginDto dto)
        {
            try
            {
                var User = context.Usuario.FirstOrDefault(x => x.Apelido == dto.Apelido);
                if(User == null)
                {
                    throw new ExceptionService("Usuário ou senha inválidos!");
                }

                var Valid = BCrypt.Net.BCrypt.Verify(dto.Senha, User.Senha);

                if (!Valid)
                {
                    throw new ExceptionService("Usuário ou senha inválidos!");
                }

                var token = createToken.Create(User);
                
                // var token = claimsService.ClaimsUser(User.Id);

                var usuarioLogado = new LoginUserDto();

                usuarioLogado.Apelido = User.Apelido;
                usuarioLogado.NomeUsuario = User.NomeUsuario;
                usuarioLogado.Id = User.Id;
                usuarioLogado.Token = token;

                return usuarioLogado;
            }
            catch(Exception ex)
            {
                throw new ExceptionService(ex.Message);
            }


        }



        public LoginUserDto Create(LoginCreateDto dto)
        {
            var Valid = VerifyUser(dto.Apelido);
            if (Valid)
            {
                throw new ExceptionService("Usuário já cadastrado!");
            }
            UsuarioModel model = new UsuarioModel();
            model.NomeUsuario = dto.Nome;
            model.Apelido = dto.Apelido;
            model.Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

            var obj = context.Usuario.Add(model);
            context.SaveChanges();

            var teste = dto.Claims;

            foreach(var itens in dto.Claims)
            {
                claimsService.newClaims(model.Id, itens.ClaimsValue, itens.ClaimName);
            }


            return new LoginUserDto(model);


        }

        public List<LoginUserDto> SelectAll()
        {
            var listUsers = context.Usuario.ToList();

            List<Claims> nova = new List<Claims>();



            var dto = new List<LoginUserDto>();

            foreach (var itens in listUsers)
            {
                var listClaims = context.Claims.Where(x => x.IdUser == itens.Id);


                dto.Add(new LoginUserDto { Apelido = itens.Apelido, NomeUsuario = itens.NomeUsuario, Id = itens.Id, Claims = listClaims.ToList() });


            }

            return dto;
        }
        private bool VerifyUser(string apelido)
        {
            var User = context.Usuario.FirstOrDefault(x => x.Apelido == apelido);
            if (User != null)
            {
                return true;
            }
            return false;
        }
        public void DeleteAll()
        {
            foreach (var itens in context.Usuario.ToList())
            {
                context.Remove(itens);
                context.SaveChanges();
            }
        }


        public Claim SelectAllClaims()
        {
            throw new NotImplementedException();
        }
    }
}
