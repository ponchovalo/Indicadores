using Indicadores.Entidades.Descripcion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Descripcion
{
    public class ActividadMap : IEntityTypeConfiguration<Actividad>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Actividad> builder)
        {
            builder.ToTable("actividad")
                .HasKey(a => a.idactividad);
        }
    }
}
