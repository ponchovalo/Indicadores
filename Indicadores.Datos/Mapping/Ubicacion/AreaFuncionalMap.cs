using Indicadores.Entidades.Ubicacion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Ubicacion
{
    public class AreaFuncionalMap : IEntityTypeConfiguration<AreaFuncional>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AreaFuncional> builder)
        {
            builder.ToTable("areafuncional")
                .HasKey(h => h.idareafuncional);
        }
    }
}
