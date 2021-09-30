using Indicadores.Entidades.Impresion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Impresion
{
    public class AlmacenImpresionMap : IEntityTypeConfiguration<AlmacenImpresion>
    {
        public void Configure(EntityTypeBuilder<AlmacenImpresion> builder)
        {
            builder.ToTable("almacenimpresion")
                .HasKey(i => i.id);
        }
    }
}
