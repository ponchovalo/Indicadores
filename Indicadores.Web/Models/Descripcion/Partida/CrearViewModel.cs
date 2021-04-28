using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Indicadores.Web.Models.Descripcion.Partida
{
    public class CrearViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe tener mas de 50 caracteres, ni menos de 3 caracteres")]
        public string nompartida { get; set; }
        [StringLength(256)]
        public string despartida { get; set; }
    }
}
