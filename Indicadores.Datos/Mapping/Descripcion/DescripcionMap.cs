using Microsoft.EntityFrameworkCore;
using Indicadores.Entidades.Descripcion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Descripcion
{
    public class DescripcionMap : IEntityTypeConfiguration<Desc>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Desc> builder)
        {
            builder.ToTable("descripcion")
                .HasKey(d => d.iddescripcion);
        }
    }
}
