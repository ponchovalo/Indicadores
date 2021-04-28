using Indicadores.Entidades.Bitacora;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Bitacora
{
    public class HojaMap : IEntityTypeConfiguration<Hoja>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Hoja> builder)
        {
            builder.ToTable("hoja")
                .HasKey(c => c.idhoja);
        }
    }
}
