using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThrApi.Models.Login
{
    [Table("Claims")]
    public class Claims
    {
        private Guid id;
        private string claimName;
        private string claimValue;
        private Guid idUser;

        public Guid Id { get => id; set => id = value; }
        public string ClaimName { get => claimName; set => claimName = value; }
        public string ClaimValue { get => claimValue; set => claimValue = value; }
        public Guid IdUser { get => idUser; set => idUser = value; }
    }
}
