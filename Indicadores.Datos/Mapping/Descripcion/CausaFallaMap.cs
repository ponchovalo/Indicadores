using Indicadores.Entidades.Descripcion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Descripcion
{
    public class CausaFallaMap : IEntityTypeConfiguration<CausaFalla>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CausaFalla> builder)
        {
            builder.ToTable("causafalla")
                .HasKey(a => a.idcausafalla);
        }
    }
}
