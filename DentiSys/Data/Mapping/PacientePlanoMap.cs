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
    public class PacientePlanoMap : IEntityTypeConfiguration<PacientePlano>
    {
        public void Configure(EntityTypeBuilder<PacientePlano> builder)
        {
            builder.HasKey(p => new {p.IdPlano,p.IdPaciente});

            builder.Property(p => p.PlanoAtivo)
                .HasColumnType("BIT");
        }
    }
}
