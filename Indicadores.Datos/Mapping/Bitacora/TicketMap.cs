using Indicadores.Entidades.Bitacora;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Datos.Mapping.Bitacora
{
    public class TicketMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("ticket")
                .HasKey(c => c.idticket);
        }
    }
}
