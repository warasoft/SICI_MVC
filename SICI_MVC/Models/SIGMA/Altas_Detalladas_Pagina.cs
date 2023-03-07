using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICI_MVC.Models.SIGMA;

namespace SICI_MVC.Models.SIGMA
{
    public class Altas_Detalladas_Pagina : BaseModelo
    {
        public List<SIGMA_spAltas_Detalladas_Obtener_Result> Altas_Detalladas { get; set; }
    }
}