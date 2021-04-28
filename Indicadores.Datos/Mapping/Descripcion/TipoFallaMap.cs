using Indicadores.Entidades.Descripcion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Descripcion
{
    public class TipoFallaMap : IEntityTypeConfiguration<TipoFalla>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TipoFalla> builder)
        {
            builder.ToTable("tipofalla")
                .HasKey(a => a.idtipofalla);
        }
    }
}
