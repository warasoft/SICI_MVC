using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICI_MVC.Models.SIGMA;

namespace SICI_MVC.Models.SIGMA
{
    public class Amortizaciones_Anuales_Pagina : BaseModelo
    {
        public List<SIGMA_spAmortizaciones_Anuales_Obtener_Result> Amortizaciones_Anuales { get; set; }
    }
}