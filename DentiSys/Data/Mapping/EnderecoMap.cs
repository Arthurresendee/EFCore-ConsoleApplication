using DentiSys.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentiSys.Data.Mapping
{
    internal class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn(1,1);


            builder.Property(e => e.CEP)
                .HasColumnName("CEP")
                .HasColumnType("nvarhar")
                .HasMaxLength(8)
                .HasMaxLength(8)
                .IsRequired(true);

            builder.Property(e => e.Pais)
                .HasColumnName("Pais")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(e => e.Estado)
                .HasColumnName("Estado")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(e => e.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(e => e.Rua)
                .HasColumnName("Rua")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(e => e.Numero)
                .HasColumnName("Numero")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.HasIndex(e => e.CEP, "IX_Endereco_CEP")
                .IsUnique();

        }
    }
}
