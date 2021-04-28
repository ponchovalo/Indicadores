using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Indicadores.Entidades.Descripcion
{
    public class Partida
    {
        public int idpartida { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage ="El nombre no debe tener mas de 50 caracteres, ni menos de 3 caracteres")]
        public string nompartida { get; set; }
        [StringLength(256)]
        public string despartida { get; set; }

        public virtual ICollection<Dispositivo> dispositivos { get; set; }
    }
}
