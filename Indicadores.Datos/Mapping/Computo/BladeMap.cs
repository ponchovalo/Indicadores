using Indicadores.Entidades.Computo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Computo
{
    public class BladeMap : IEntityTypeConfiguration<Blade>
    {
        public void Configure(EntityTypeBuilder<Blade> builder)
        {
            builder.ToTable("blade")
                .HasKey(i => i.bladeid);
        }
    }
}
