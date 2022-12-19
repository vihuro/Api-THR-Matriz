using System.ComponentModel.DataAnnotations.Schema;
using ThrApi.Dto.Login;

namespace ThrApi.Models.Login
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        private Guid id;
        private string nomeUsuario;
        private string apelido;
        private string senha;

        public UsuarioModel() { }


        public Guid Id { get => id; set => id = value; }
        public string NomeUsuario { get => nomeUsuario; set => nomeUsuario = value; }
        public string Apelido { get => apelido; set => apelido = value; }
        public string Senha { get => senha; set => senha = value; }
    }

}
