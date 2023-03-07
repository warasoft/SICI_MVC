using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICI_MVC.Models.SIGMA;

namespace SICI_MVC.Models.SIGMA
{
    public class Lotes_Inventario_Pagina : BaseModelo
    {
        public List<SIGMA_spLotes_Inventario_Obtener_Result> Lotes_Inventario { get; set; }
    }
}