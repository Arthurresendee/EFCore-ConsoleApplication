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
    public class DentistaMap : IEntityTypeConfiguration<Dentista>
    {
        public void Configure(EntityTypeBuilder<Dentista> builder)
        {
            builder.ToTable("Dentistas");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("nvarhar")
                .HasMaxLength(200)
                .IsRequired(true);

            builder.Property(x => x.SobreNome)
                .HasColumnName("CEP")
                .HasColumnType("nvarhar")
                .HasMaxLength(8)
                .IsRequired(true);

            builder.Property(x => x.Idade)
                .HasColumnName("Idade")
                .HasColumnType("INT")
                .IsRequired(false);

            builder.Property(x => x.CPF)
                .HasColumnName("CPF")
                .HasColumnType("nvarhar")
                .HasMaxLength(11)
                .IsRequired(false);

            builder.Property(x => x.DataDeAniversario)
                .HasColumnName("DataDeAniversario")
                .HasColumnType("SMALDATETIME")
                .IsRequired(false);

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarhar")
                .HasMaxLength(5)
                .IsRequired(false);

            builder.Property(x => x.NumeroDeTelefone)
                .HasColumnName("NumeroDeTelefone")
                .HasColumnType("nvarhar")
                .HasMaxLength(15)
                .IsRequired(false);

            builder.Property(x => x.Especializacao)
                .HasColumnName("Especialização")
                .HasColumnType("TEXT")
                .IsRequired(false);

            builder.Property(x => x.NumeroDeRegistro)
                .HasColumnName("NumeroDeRegistro")
                .HasColumnType("nvarhar")
                .HasMaxLength(9)
                .IsRequired(false);

        }
    }
}
