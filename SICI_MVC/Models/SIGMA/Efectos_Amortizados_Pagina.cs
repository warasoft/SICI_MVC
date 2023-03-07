using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICI_MVC.Models.SIGMA;

namespace SICI_MVC.Models.SIGMA
{
    public class Efectos_Amortizados_Pagina : BaseModelo
    {
        public List<SIGMA_spEfectos_Amortizados_Obtener_Result> Efectos_Amortizados { get; set; }
    }
}