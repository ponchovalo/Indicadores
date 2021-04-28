using System.ComponentModel.DataAnnotations;

namespace Indicadores.Entidades.Descripcion
{
    public class Dispositivo
    {
        public int iddispositivo { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe tener mas de 50 caracteres, ni menos de 3 caracteres")]
        public int partidaidpartida { get; set; }
        public string nomdispositivo { get; set; }
        [StringLength(256)]
        public string desdispositivo { get; set; }
        public Partida partida { get; set; }
    }
}
