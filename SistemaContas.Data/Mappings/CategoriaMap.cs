using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaContas.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContas.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA");

            builder.HasKey(c => c.IdCategoria);
            builder.Property(c => c.IdCategoria)
                .HasColumnName("IDCATEGORIA");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();


            builder.Property(c => c.Tipo)
                .HasColumnName("TIPO")
                .IsRequired();

            builder.Property(c => c.IdUsuario)
                .HasColumnName("IDUSUARIO")
                .IsRequired();

            builder.HasOne(c => c.Usuario) //categoria pertecne a 1 usuario
                .WithMany(u => u.Categorias) // usuario tem muitas categorias
                .HasForeignKey(c => c.IdUsuario) //cardinalidade FK
                .OnDelete(DeleteBehavior.NoAction); 
        }
    }
}
