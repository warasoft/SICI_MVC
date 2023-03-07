using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICI_MVC.Models
{
    public class Peliculas_Pagina : BaseModelo
    {
        public List<SIGMA_spPeliculas_Seleccionar_Result> Peliculas { get; set; }
    }
}