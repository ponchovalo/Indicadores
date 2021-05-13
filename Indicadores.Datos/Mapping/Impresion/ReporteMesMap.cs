using Indicadores.Entidades.Impresion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Impresion
{
    class ReporteMesMap : IEntityTypeConfiguration<ReporteMes>
    {
        public void Configure(EntityTypeBuilder<ReporteMes> builder)
        {
            builder.ToTable("reportemes")
                .HasKey(i => i.idreporte);
        }
    }
}
