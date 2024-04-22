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
    public class PlanoMap : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.ToTable("Planos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Titulo)
                .HasColumnName("Titulo")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.TipoDePlano)
                .HasColumnName("TipoDePlano")
                .HasColumnType("INT")
                .IsRequired(false);

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired(false);

            builder.Property(x => x.Coberturas)
                .HasColumnName("Coberturas")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.DataInicial)
                .HasColumnName("DataInicial")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now)
                .IsRequired(false);

            builder.Property(x => x.DataFinal)
                .HasColumnName("DataFinal")
                .HasColumnType("SMALLDATETIME")
                .IsRequired(false);
        }
    }
}
