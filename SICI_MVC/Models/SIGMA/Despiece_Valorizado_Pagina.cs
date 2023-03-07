using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICI_MVC.Models.SIGMA;

namespace SICI_MVC.Models.SIGMA
{
    public class Despiece_Valorizado_Pagina : BaseModelo
    {
        public List<SIGMA_spDespiece_Valorizado_Obtener_Result> Despiece_Valorizado { get; set; }
    }
}