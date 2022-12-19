using ThrApi.Models.Login;

namespace ThrApi.Interface.Login
{
    public interface ICreateToken
    {
        public string Create(UsuarioModel user);
    }
}
