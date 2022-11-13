using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TesteLabs.Domain;

namespace TesteLabs.Data
{
    public class TesteLabsContext : IdentityDbContext
    {
        public TesteLabsContext (DbContextOptions<TesteLabsContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Paises> Paises { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Cidades> Cidades { get; set; }
        public DbSet<FuncionariosEnderecos> FuncionariosEnderecos { get; set; }
    }
}
