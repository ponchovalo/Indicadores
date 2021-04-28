using Indicadores.Entidades.Descripcion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Descripcion
{
    public class SolucionMap : IEntityTypeConfiguration<Solucion>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Solucion> builder)
        {
            builder.ToTable("solucion")
                .HasKey(a => a.idsolucion);
        }
    }
}
