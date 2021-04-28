using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Almacen
{
    public class Insumo
    {
        public int idinsumo { get; set; }
        public int categoriaidcategoria { get; set; }
        public string nominsumo { get; set; }
        public string desinsumo { get; set; }
        public Categoria categoria { get; set; }
    }
}
