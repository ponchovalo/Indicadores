using Indicadores.Entidades.Descripcion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Descripcion
{
    public class DispositivoMap : IEntityTypeConfiguration<Dispositivo>
    {
        public void Configure(EntityTypeBuilder<Dispositivo> builder)
        {
            builder.ToTable("dispositivo")
                .HasKey(d => d.iddispositivo);
        }
    }
}
