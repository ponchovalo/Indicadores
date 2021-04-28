using Indicadores.Entidades.Almacen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Almacen
{
    public class HerramientaMap : IEntityTypeConfiguration<Herramienta>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Herramienta> builder)
        {
            builder.ToTable("herramienta")
                .HasKey(h => h.idherramienta);
        }
    }
}
