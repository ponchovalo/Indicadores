using Indicadores.Entidades.Almacen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Almacen
{
    public class InsumoMap : IEntityTypeConfiguration<Insumo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Insumo> builder)
        {
            builder.ToTable("insumo")
                .HasKey(h => h.idinsumo);
        }
    }
}
