using Indicadores.Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Usuarios
{
    public class AreaMap : IEntityTypeConfiguration<Area>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("area")
                .HasKey(a => a.idarea);
        }
    }
}
