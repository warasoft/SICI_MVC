using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICI_MVC.Models.SIGMA;

namespace SICI_MVC.Models.SIGMA
{
    public class Altas_Generales_Pagina : BaseModelo
    {
        public List<SIGMA_spAltas_Generales_Obtener_Result> Altas_Generales { get; set; }
    }
}