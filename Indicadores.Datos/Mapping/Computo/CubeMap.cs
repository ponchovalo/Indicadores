using Indicadores.Entidades.Computo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Computo
{
    public class CubeMap : IEntityTypeConfiguration<Cube>
    {
        public void Configure(EntityTypeBuilder<Cube> builder)
        {
            builder.ToTable("cube")
                .HasKey(i => i.cubeid);
        }
    }
}
