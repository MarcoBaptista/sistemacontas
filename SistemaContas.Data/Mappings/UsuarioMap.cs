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
    /// <summary>
    /// Mapeamento para entridade Map
    /// </summary>

    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //nome da tabela
            builder.ToTable("USUARIO");
            
            //chave primaria
            builder.HasKey(u => u.IdUsuario);

            //campos da tabela
            builder.Property(u => u.IdUsuario)
                .HasColumnName("IDUSUARIO");
            
            builder.Property(u => u.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(50)
                .IsRequired();
            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(u => u.DataCriacao)
                .HasColumnName("DATACRIACAO")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(u => u.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();


        }
    }
}
