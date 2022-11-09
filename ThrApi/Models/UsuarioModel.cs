using System.ComponentModel.DataAnnotations.Schema;

namespace ThrApi.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        private int id;
        private string nomeUsuario;
        private string apelido;
        private string senha;

        public int Id { get => id; set => id = value; }
        public string NomeUsuario { get => nomeUsuario; set => nomeUsuario = value; }
        public string Apelido { get => apelido; set => apelido = value; }
        public string Senha { get => senha; set => senha = value; }
    }
}
