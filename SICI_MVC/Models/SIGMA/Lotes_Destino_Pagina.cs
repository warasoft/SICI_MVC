using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICI_MVC.Models.SIGMA;

namespace SICI_MVC.Models.SIGMA
{
    public class Lotes_Destino_Pagina : BaseModelo
    {
        public List<SIGMA_spLotes_Destino_Obtener_Result> Lotes_Destino { get; set; }
    }
}