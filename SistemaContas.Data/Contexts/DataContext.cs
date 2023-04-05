using Microsoft.EntityFrameworkCore;
using SistemaContas.Data.Entities;
using SistemaContas.Data.Mappings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContas.Data.Contexts
{
    /// <summary>
    /// Contexto do EntityFramework
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Sobrescrita de métto para confiruar conex com bd
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDSistemaContas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        /// <summary>
        /// Incluir cada classe criada para adicionar ao bd
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ContaMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
        }

        /// <summary>
        /// Propriedade unidade de trabalho para entidade Usuario
        /// </summary>
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

    }
}
