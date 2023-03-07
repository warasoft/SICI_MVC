using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICI_MVC.Models.SICI
{
    public class Amortizacion_Detallada
    {
        public int Id_Amortizacion_Detallada { get; set; }
        public string Sigla { get; set; }
        public string Tipo_Bien { get; set; }
        public string Descripcion_Inventario { get; set; }
        public decimal[] Amortizaciones { get; set; }
    }
}