using Indicadores.Entidades.Ubicacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Ubicacion
{
    public class UbicacionFuncionalMap : IEntityTypeConfiguration<UbicacionFuncional>
    {
        public void Configure(EntityTypeBuilder<UbicacionFuncional> builder)
        {
            builder.ToTable("ubicacionfuncional")
                .HasKey(h => h.idubicacionfuncional);
        }
    }
}
