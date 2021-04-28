using Indicadores.Entidades.Descripcion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Indicadores.Datos.Mapping.Descripcion
{
    class TipoActividadMap : IEntityTypeConfiguration<TipoActividad>
    {
        public void Configure(EntityTypeBuilder<TipoActividad> builder)
        {
            builder.ToTable("tipoactividad")
                .HasKey(a => a.idtipoactividad);
        }
    }
}
