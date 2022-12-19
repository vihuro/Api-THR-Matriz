using ThrApi.Models.Login;

namespace ThrApi.Dto.Login
{
    public class LoginDto
    {
        private string apelido;
        private string senha;


        public LoginDto() { }
        public LoginDto(UsuarioModel model)
        {
            this.apelido = model.Apelido;
            this.senha = model.Senha;
        }
        public string Apelido { get => apelido; set => apelido = value; }
        public string Senha { get => senha; set => senha = value; }

    }
}
