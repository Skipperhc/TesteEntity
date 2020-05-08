using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteEntity.Models;

namespace TesteEntity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TesteEntity.Models.Endereco> Endereco { get; set; }
        public DbSet<TesteEntity.Models.Telefone> Telefone { get; set; }
        public DbSet<TesteEntity.Models.Pessoa> Pessoa { get; set; }
    }
}
