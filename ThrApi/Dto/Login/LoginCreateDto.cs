using ThrApi.Models.Login;

namespace ThrApi.Dto.Login
{
    public class LoginCreateDto
    {
        private string nomeUsuario;
        private string apelido;
        private string senha;
        private List<ClaimsCreateUserDto> claims;

        public LoginCreateDto()
        {

        }
        public LoginCreateDto(UsuarioModel model)
        {
            this.nomeUsuario = model.NomeUsuario;
            this.apelido = model.Apelido;
        }


        public string Nome { get => nomeUsuario; set => nomeUsuario = value; }
        public string Apelido { get => apelido; set => apelido = value; }
        public string Senha { get => senha; set => senha = value; }
        public List<ClaimsCreateUserDto> Claims { get => claims; set => claims = value; }
    }
}
