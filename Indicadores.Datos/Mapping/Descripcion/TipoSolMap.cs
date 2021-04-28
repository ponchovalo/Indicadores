using Indicadores.Entidades.Descripcion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Descripcion
{
    public class TipoSolMap : IEntityTypeConfiguration<TipoSol>
    {
        public void Configure(EntityTypeBuilder<TipoSol> builder)
        {
            builder.ToTable("tiposol")
                .HasKey(a => a.idtiposol);
        }
    }
}
