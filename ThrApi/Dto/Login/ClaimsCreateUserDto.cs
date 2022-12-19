using ThrApi.Models.Login;

namespace ThrApi.Dto.Login
{
    public class ClaimsCreateUserDto
    {
        private string claimName;
        private string claimsValue;
        private Guid userID;

        public ClaimsCreateUserDto()
        {

        }
        public ClaimsCreateUserDto(Claims model)
        {
            this.ClaimName = model.ClaimName;
            this.claimsValue = model.ClaimValue;
            this.UserID = model.Id;
        }
        public string ClaimName { get => claimName; set => claimName = value; }
        public string ClaimsValue { get => claimsValue; set => claimsValue = value; }
        public Guid UserID { get => userID; set => userID = value; }
    }
}
