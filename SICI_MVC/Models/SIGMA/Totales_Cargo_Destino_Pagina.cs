using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICI_MVC.Models.SIGMA;

namespace SICI_MVC.Models.SIGMA
{
    public class Totales_Cargo_Destino_Pagina : BaseModelo
    {
        public List<SIGMA_spTotales_Cargo_Destino_Obtener_Result> Totales_Cargo_Destino { get; set; }
    }
}