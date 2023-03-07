using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICI_MVC.Models.SIGMA;

namespace SICI_MVC.Models.SIGMA
{
    public class Descargos_Valorizados_Pagina : BaseModelo
    {
        public List<SIGMA_spDescargos_Valorizados_Obtener_Result> Descargos_Valorizados { get; set; }
    }
}