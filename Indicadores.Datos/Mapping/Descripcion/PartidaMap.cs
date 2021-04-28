using Indicadores.Entidades.Descripcion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Descripcion
{
    public class PartidaMap : IEntityTypeConfiguration<Partida>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Partida> builder)
        {
            builder.ToTable("partida")
                .HasKey(c => c.idpartida);
            builder.Property(c => c.nompartida)
                .HasMaxLength(50);
            builder.Property(c => c.despartida)
                .HasMaxLength(256);
        }
    }
}
