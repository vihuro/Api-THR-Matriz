using System.Security.Claims;
using ThrApi.Dto.Login;

namespace ThrApi.Interface.Login
{
    public interface ILogin
    {

        LoginUserDto Logar(LoginDto dto);
        LoginUserDto Create(LoginCreateDto dto);
        void DeleteAll ();
        List<LoginUserDto> SelectAll();
        Claim SelectAllClaims();
    }
}
