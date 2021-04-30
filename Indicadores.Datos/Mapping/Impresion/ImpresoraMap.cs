using Indicadores.Entidades.Impresora;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Impresion
{
    public class ImpresoraMap : IEntityTypeConfiguration<Impresora>
    {
        public void Configure(EntityTypeBuilder<Impresora> builder)
        {
            builder.ToTable("impresora")
                .HasKey(i => i.idimpresora);
        }
    }
}
