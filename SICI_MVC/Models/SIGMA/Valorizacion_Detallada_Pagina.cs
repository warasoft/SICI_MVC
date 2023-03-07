using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICI_MVC.Models.SIGMA;

namespace SICI_MVC.Models.SIGMA
{
    public class Valorizacion_Detallada_Pagina : BaseModelo
    {
        public List<SIGMA_spValorizacion_Detallada_Obtener_Result> Valorizacion_Detallada { get; set; }
    }
}