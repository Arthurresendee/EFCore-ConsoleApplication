﻿using DentiSys.Models;
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
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.SobreNome)
                .HasColumnName("CEP")
                .HasColumnType("nvarchar")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(x => x.Idade)
                .HasColumnName("Idade")
                .HasColumnType("INT")
                .IsRequired(false);

            builder.Property(x => x.CPF)
                .HasColumnName("CPF")
                .HasColumnType("nvarchar")
                .HasMaxLength(11)
                .HasDefaultValue("00000000000")
                .IsRequired(false);

            builder.Property(x => x.DataDeAniversario)
                .HasColumnName("DataDeAniversario")
                .HasColumnType("SMALLDATETIME")
                .IsRequired(false);

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(5)
                .IsRequired(false);

            builder.Property(x => x.NumeroDeTelefone)
                .HasColumnName("NumeroDeTelefone")
                .HasColumnType("nvarchar")
                .HasMaxLength(15)
                .IsRequired(false);

            builder.Property(x => x.Especializacao)
                .HasColumnName("Especialização")
                .HasColumnType("TEXT")
                .IsRequired(false);

            builder.Property(x => x.NumeroDeRegistro)
                .HasColumnName("NumeroDeRegistro")
                .HasColumnType("nvarchar")
                .HasMaxLength(9)
                .IsRequired(false);

            builder.Property(x => x.IdEndereco)
                .HasColumnName("IdEndereco")
                .HasColumnType("INT")
                .IsRequired();

            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Dentista)
                .HasForeignKey<Dentista>(x => x.IdEndereco)
                .IsRequired();
        }
    }
}
