using Indicadores.Entidades.Descripcion;
using Microsoft.EntityFrameworkCore;


namespace Indicadores.Datos.Mapping.Descripcion
{
    public class AtribuibleMap : IEntityTypeConfiguration<Atribuible>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Atribuible> builder)
        {
            builder.ToTable("atribuible")
                .HasKey(a => a.idatribuible);
        }
    }
}
