using Microsoft.EntityFrameworkCore;
using ThrApi.Models.Estoque;

namespace ThrApi.Context
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options){ }
        public DbSet<MovimentacaoEstoqueModel> Movimentacao { get; set; }
    }
}
