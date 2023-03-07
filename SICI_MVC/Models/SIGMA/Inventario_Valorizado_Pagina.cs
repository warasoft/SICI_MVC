using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICI_MVC.Models.SIGMA;

namespace SICI_MVC.Models.SIGMA
{
    public class Inventario_Valorizado_Pagina : BaseModelo
    {
        public List<SIGMA_spInventario_Valorizado_Obtener_Result> Inventario_Valorizado { get; set; }
    }
}