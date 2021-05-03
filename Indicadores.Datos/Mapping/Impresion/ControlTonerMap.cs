using Indicadores.Entidades.Impresion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Impresion
{
    public class ControlTonerMap : IEntityTypeConfiguration<ControlToner>
    {
        public void Configure(EntityTypeBuilder<ControlToner> builder)
        {
            builder.ToTable("controltoner")
                .HasKey(i => i.idcontrol);
                
            
        }
    }
}
