using Indicadores.Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Usuarios
{
    public class PuestoMap : IEntityTypeConfiguration<Puesto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Puesto> builder)
        {
            builder.ToTable("puesto")
                .HasKey(p => p.idpuesto);
        }
    }
}
