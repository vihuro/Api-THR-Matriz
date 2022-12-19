using ThrApi.Models.Login;

namespace ThrApi.Dto.Login
{
    public class LoginUserDto
    {
        private Guid id;
        private string nomeUsuario;
        private string apelido;
        private string token;
        private List<Claims> claims;

        public LoginUserDto(UsuarioModel model)
        {
            this.id = model.Id;
            this.nomeUsuario = model.NomeUsuario;
            this.apelido = model.Apelido;

        }
        public LoginUserDto()
        {

        }

        public Guid Id { get => id; set => id = value; }
        public string NomeUsuario { get => nomeUsuario; set => nomeUsuario = value; }
        public string Apelido { get => apelido; set => apelido = value; }
        public string Token { get => token; set => token = value; }
        public List<Claims> Claims { get => claims; set => claims = value; }
    }
}
