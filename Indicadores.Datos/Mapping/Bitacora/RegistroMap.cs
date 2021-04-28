using Indicadores.Entidades.Bitacora;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Bitacora
{
    public class RegistroMap : IEntityTypeConfiguration<Registro>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Registro> builder)
        {
            builder.ToTable("registro")
                .HasKey(c => c.idregistro);
        }
    }
}
