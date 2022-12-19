using ThrApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThrApi.Models.Login;
using ThrApi.Models.Estoque;

namespace ThrApi.Context
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {

        }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<Claims> Claims { get; set; }
        public DbSet<ProdutosModel> Produtos { get; set; }
    }
}
