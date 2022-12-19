using ThrApi.Context;
using ThrApi.Interface.Login;
using ThrApi.Models.Login;

namespace ThrApi.Service.Login
{
    public class ClaimsService : IClaims
    {
        private readonly UsuarioContext context;
        public ClaimsService(UsuarioContext context)
        {
            this.context = context;
        }

        public  Claims newClaims(Guid idUser, string value, string namae)
        {
            Claims claims = new Claims();
            claims.IdUser = idUser;
            claims.ClaimValue = value;
            claims.ClaimName = namae;

            context.Claims.Add(claims);
            context.SaveChanges();

            return claims;
        }

        public List<Claims> ClaimsUser(Guid idUser)
        {
            return context.Claims.Where(x => x.IdUser == idUser).ToList();
        }
    }
}
