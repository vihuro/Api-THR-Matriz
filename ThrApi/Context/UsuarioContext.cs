using ThrApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ThrApi.Context
{
    public class UsuarioContext : IdentityDbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {

        }
        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
