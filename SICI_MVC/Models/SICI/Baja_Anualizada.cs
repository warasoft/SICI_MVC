using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICI_MVC.Models.SICI
{
    public class Baja_Anualizada
    {
        public int Id_Baja_Anualizada { get; set; }
        public string Sigla { get; set; }
        public string Tipo_Bien { get; set; }
        public string Descripcion_Inventario { get; set; }
        public decimal[] Totales_Residuales { get; set; }
    }
}