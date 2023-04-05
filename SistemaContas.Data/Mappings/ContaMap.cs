using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaContas.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContas.Data.Mappings
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("CONTA");

            builder.HasKey(c => c.IdConta);

            builder.Property(c => c.IdConta)
                .HasColumnName("IDCONTA")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(c => c.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.IdCategoria)
                .HasColumnName("IDCATEGORIA")
                .IsRequired();

            builder.Property(c => c.IdUsuario)
                .HasColumnName("IDUSUARIO")
                .IsRequired();

            builder.HasOne(c => c.Categoria) //CONTA PERTENCE A 1 CATEGORIA
               .WithMany(c => c.Contas) //CATEGORIA TEM MUITAS CONTAS
               .HasForeignKey(c => c.IdCategoria)
               .OnDelete(DeleteBehavior.NoAction); //CHAVE ESTRANGEIRA

            builder.HasOne(c => c.Usuario) //CONTA PERTENCE A 1 USUARIO
                .WithMany(u => u.Contas) //USUARIO TEM MUITAS CONTAS
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction); //CHAVE ESTRANGEIRA

        }
    }
}
