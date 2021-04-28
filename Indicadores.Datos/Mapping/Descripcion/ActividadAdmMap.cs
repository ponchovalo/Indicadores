using Indicadores.Entidades.Descripcion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Descripcion
{
    public class ActividadAdmMap : IEntityTypeConfiguration<ActividadAdm>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ActividadAdm> builder)
        {
            builder.ToTable("actividadadm")
                .HasKey(a => a.idactividadadm);
        }
    }
}
