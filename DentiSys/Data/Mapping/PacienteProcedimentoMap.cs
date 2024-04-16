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
    public class PacienteProcedimentoMap : IEntityTypeConfiguration<PacienteProcedimento>
    {
        public void Configure(EntityTypeBuilder<PacienteProcedimento> builder)
        {
            builder.ToTable("PacienteProcedimentos");

            builder.HasKey(x => new {x.IdPaciente, x.IdProcedimento});

            builder.Property(x => x.IdPaciente)
                .IsRequired();

            builder.Property(x => x.IdProcedimento)
                .IsRequired();

            builder.Property(x => x.DataProcedimento)
                .IsRequired()
                .HasColumnName("DataProcedimento")
                .HasColumnType("SMALLDATETIME")
                .IsRequired();

            builder.HasIndex(x => x.ProcedimentoRealizado, "IX_PacienteProcedimento_ProcedimentoRealizado")
                .IsUnique();

        }
    }
}
