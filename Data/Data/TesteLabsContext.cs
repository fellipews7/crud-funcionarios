using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class TesteLabsContext : DbContext
    {
        public TesteLabsContext(DbContextOptions<TesteLabsContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<FuncionarioCargo> FuncionarioCargo { get; set; }
    }
}
