using ThrApi.Models.Login;

namespace ThrApi.Interface.Login
{
    public interface IClaims
    {
        Claims newClaims(Guid idUser, string value, string namae);
        List<Claims> ClaimsUser(Guid idUser);
    }
}
