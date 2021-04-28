using Indicadores.Entidades.Descripcion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Descripcion
{
    public class CatFallaMap : IEntityTypeConfiguration<CatFalla>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CatFalla> builder)
        {
            builder.ToTable("catfalla")
                .HasKey(a => a.idcatfalla);
        }
    }
}
