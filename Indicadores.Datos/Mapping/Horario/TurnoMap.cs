using Indicadores.Entidades.Horario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Horario
{
    public class TurnoMap : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            builder.ToTable("turno")
                .HasKey(h => h.idturno);
        }
    }
}
