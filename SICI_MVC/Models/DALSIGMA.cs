using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SICI_MVC.Models
{
    public class DALSIGMA
    {
        public static List<SIGMA_spPeliculas_Seleccionar_Result> Obtener_Peliculas(string sPAIS, string sAÑO, string sFECHA_DESDE, string sFECHA_HASTA)
        {
            SIGMAEntities db = new SIGMAEntities();

            List<SIGMA_spPeliculas_Seleccionar_Result> lista = new List<SIGMA_spPeliculas_Seleccionar_Result>();

            int iAÑO = 0;

            DateTime dFecha_Desde = DateTime.MaxValue;
            DateTime dFecha_Hasta = DateTime.MaxValue;

            if (sAÑO.Trim() != "")
            {
                iAÑO = int.Parse(sAÑO);
            }
            if (sFECHA_DESDE.Length == 10)
            {
                dFecha_Desde = DateTime.Parse(sFECHA_DESDE);
            }
            if (sFECHA_HASTA.Length == 10)
            {
                dFecha_Hasta = DateTime.Parse(sFECHA_HASTA);
            }

            lista = db.SIGMA_spPeliculas_Seleccionar(sPAIS, iAÑO, dFecha_Desde, dFecha_Hasta).ToList();

            return lista;
        }

        public static List<SIGMA_spAltas_Anuales_Obtener_Result> Obtener_Altas_Anuales(string sAÑO_Desde, string sAÑO_Hasta)
        {
            SIGMAEntities db = new SIGMAEntities();

            int iAÑO_Desde = 0;
            int iAÑO_Hasta = 0;

            if (sAÑO_Desde.Trim() != "")
            {
                iAÑO_Desde = int.Parse(sAÑO_Desde);
            }
            if (sAÑO_Hasta.Trim() != "")
            {
                iAÑO_Hasta = int.Parse(sAÑO_Hasta);
            }

            List<SIGMA_spAltas_Anuales_Obtener_Result> lista = db.SIGMA_spAltas_Anuales_Obtener(iAÑO_Desde, iAÑO_Hasta).ToList();

            return lista;
        }

        public static List<SIGMA_spAltas_Detalladas_Obtener_Result> Obtener_Altas_Detalladas(string sNNE, string sFECHA_DESDE, string sFECHA_HASTA)
        {
            SIGMAEntities db = new SIGMAEntities();

            DateTime dFecha_Desde = DateTime.MaxValue;
            DateTime dFecha_Hasta = DateTime.MaxValue;

            if (sFECHA_DESDE.Length == 10)
            {
                dFecha_Desde = DateTime.Parse(sFECHA_DESDE);
            }
            if (sFECHA_HASTA.Length == 10)
            {
                dFecha_Hasta = DateTime.Parse(sFECHA_HASTA);
            }

            List<SIGMA_spAltas_Detalladas_Obtener_Result> lista = db.SIGMA_spAltas_Detalladas_Obtener(sNNE, dFecha_Desde, dFecha_Hasta).ToList();

            return lista;
        }

        public static List<SIGMA_spAltas_Generales_Obtener_Result> Obtener_Altas_Generales(string sORIGEN, string sFECHA_DESDE, string sFECHA_HASTA)
        {
            SIGMAEntities db = new SIGMAEntities();

            DateTime dFecha_Desde = DateTime.Parse(sFECHA_DESDE);
            DateTime dFecha_Hasta = DateTime.Parse(sFECHA_HASTA);

            int idSele = 0;

            if (sORIGEN != "")
            {
                idSele = int.Parse(sORIGEN);
            }

            List<SIGMA_spAltas_Generales_Obtener_Result> lista = db.SIGMA_spAltas_Generales_Obtener(dFecha_Desde, dFecha_Hasta, idSele).ToList();

            return lista;
        }

        public static List<SIGMA_spAltas_Totalizadas_Obtener_Result> Obtener_Altas_Totalizadas(string sINVENTARIO, string sAÑO_DESDE, string sAÑO_HASTA)
        {
            SIGMAEntities db = new SIGMAEntities();

            int iAÑO_Desde = 0;
            int iAÑO_Hasta = 0;

            if (sAÑO_DESDE.Trim() != "")
            {
                iAÑO_Desde = int.Parse(sAÑO_DESDE);
            }
            if (sAÑO_HASTA.Trim() != "")
            {
                iAÑO_Hasta = int.Parse(sAÑO_HASTA);
            }

            int idSele = int.Parse(sINVENTARIO);

            List<SIGMA_spAltas_Totalizadas_Obtener_Result> lista = db.SIGMA_spAltas_Totalizadas_Obtener(idSele, iAÑO_Desde, iAÑO_Hasta).ToList();

            return lista;
        }

        public static List<SIGMA_spAmortizaciones_Anuales_Obtener_Result> Obtener_Amortizaciones_Anuales(string sFECHA_DESDE, string sFECHA_HASTA, string sNROLOTE, string sNNE)
        {
            SIGMAEntities db = new SIGMAEntities();

            DateTime dFecha_Desde = DateTime.Parse(sFECHA_DESDE);
            DateTime dFecha_Hasta = DateTime.Parse(sFECHA_HASTA);

            List<SIGMA_spAmortizaciones_Anuales_Obtener_Result> lista = db.SIGMA_spAmortizaciones_Anuales_Obtener(dFecha_Desde, dFecha_Hasta, sNROLOTE, sNNE).ToList();

            return lista;
        }

        public static List<SIGMA_spDescargos_Valorizados_Obtener_Result> Obtener_Descargos_Valorizados(string sFECHA_DESDE, string sFECHA_HASTA, string sSIGLA, string sNNE)
        {
            SIGMAEntities db = new SIGMAEntities();

            DateTime dFecha_Desde = DateTime.Parse(sFECHA_DESDE);
            DateTime dFecha_Hasta = DateTime.Parse(sFECHA_HASTA);

            List<SIGMA_spDescargos_Valorizados_Obtener_Result> lista = db.SIGMA_spDescargos_Valorizados_Obtener(dFecha_Desde, dFecha_Hasta, sSIGLA, sNNE).ToList();

            return lista;
        }

        public static List<SIGMA_spDespiece_Valorizado_Obtener_Result> Obtener_Despiece_Valorizado(string sNNE, string sNROINVENTARIO, string sNROSERIEEJ)
        {
            SIGMAEntities db = new SIGMAEntities();

            Int64 iNroInve = 0;

            if (sNROINVENTARIO.Trim() != "")
            {
                iNroInve = Int64.Parse(sNROINVENTARIO.Trim());
            }

            List<SIGMA_spDespiece_Valorizado_Obtener_Result> lista = db.SIGMA_spDespiece_Valorizado_Obtener(sNNE, iNroInve, sNROSERIEEJ).ToList();

            return lista;
        }

        public static List<SIGMA_spEfectos_Amortizados_Obtener_Result> Obtener_Efectos_Amortizados(string sFECHA_DESDE, string sFECHA_HASTA)
        {
            SIGMAEntities db = new SIGMAEntities();

            DateTime dFecha_Desde = DateTime.Parse(sFECHA_DESDE);
            DateTime dFecha_Hasta = DateTime.Parse(sFECHA_HASTA);

            List<SIGMA_spEfectos_Amortizados_Obtener_Result> lista = db.SIGMA_spEfectos_Amortizados_Obtener(dFecha_Desde, dFecha_Hasta).ToList();

            return lista;
        }

        public static List<SIGMA_spInventario_Valorizado_Obtener_Result> Obtener_Inventario_Valorizado(string sINVENTARIO, string sAÑO)
        {
            SIGMAEntities db = new SIGMAEntities();

            int idSele = int.Parse(sINVENTARIO);
            int iAño = int.Parse(sAÑO);

            List<SIGMA_spInventario_Valorizado_Obtener_Result> lista = db.SIGMA_spInventario_Valorizado_Obtener(idSele, iAño).ToList();

            return lista;
        }

        public static List<SIGMA_spLotes_Destino_Obtener_Result> Obtener_Lotes_Destino(string sFECHA_DESDE, string sFECHA_HASTA, string sSIGLA)
        {
            SIGMAEntities db = new SIGMAEntities();

            DateTime dFecha_Desde = DateTime.Parse(sFECHA_DESDE);
            DateTime dFecha_Hasta = DateTime.Parse(sFECHA_HASTA);

            List<SIGMA_spLotes_Destino_Obtener_Result> lista = db.SIGMA_spLotes_Destino_Obtener(dFecha_Desde, dFecha_Hasta, sSIGLA).ToList();

            return lista;
        }

        public static List<SIGMA_spLotes_Inventario_Obtener_Result> Obtener_Lotes_Inventario(string sFECHA_DESDE, string sFECHA_HASTA, string sINVENTARIO)
        {
            SIGMAEntities db = new SIGMAEntities();

            int idSele = 0;

            if (sINVENTARIO.Trim() != "")
            {
                idSele = int.Parse(sINVENTARIO);
            }

            DateTime dFecha_Desde = DateTime.Parse(sFECHA_DESDE);
            DateTime dFecha_Hasta = DateTime.Parse(sFECHA_HASTA);

            List<SIGMA_spLotes_Inventario_Obtener_Result> lista = db.SIGMA_spLotes_Inventario_Obtener(dFecha_Desde, dFecha_Hasta, idSele).ToList();

            return lista;
        }

        public static List<SIGMA_spTotales_Cargo_Destino_Obtener_Result> Obtener_Totales_Cargo_Destino(string sSIGLA, string sCARGO_DESTINO)
        {
            SIGMAEntities db = new SIGMAEntities();

            List<SIGMA_spTotales_Cargo_Destino_Obtener_Result> lista = db.SIGMA_spTotales_Cargo_Destino_Obtener(sSIGLA, sCARGO_DESTINO).ToList();

            return lista;
        }

        public static List<SIGMA_spTotales_Cargo_Efecto_Obtener_Result> Obtener_Totales_Cargo_Efecto(string sCARGO_EFECTO, string sSIGLA, string sCARGO_DESTINO)
        {
            SIGMAEntities db = new SIGMAEntities();

            List<SIGMA_spTotales_Cargo_Efecto_Obtener_Result> lista = db.SIGMA_spTotales_Cargo_Efecto_Obtener(sCARGO_EFECTO, sSIGLA, sCARGO_DESTINO).ToList();

            return lista;
        }

        public static List<SIGMA_spTotales_Destino_Obtener_Result> Obtener_Totales_Destino(string sZONA, string sSIGLA)
        {
            SIGMAEntities db = new SIGMAEntities();

            List<SIGMA_spTotales_Destino_Obtener_Result> lista = db.SIGMA_spTotales_Destino_Obtener(sZONA, sSIGLA).ToList();

            return lista;
        }

        public static List<SIGMA_spTotales_Efecto_Obtener_Result> Obtener_Totales_Efecto(string sNNE, string sSIGLA, string sCARGO_DESTINO, string sCARGO_EFECTO)
        {
            SIGMAEntities db = new SIGMAEntities();

            List<SIGMA_spTotales_Efecto_Obtener_Result> lista = db.SIGMA_spTotales_Efecto_Obtener(sNNE, sSIGLA, sCARGO_DESTINO, sCARGO_EFECTO).ToList();

            return lista;
        }

        public static List<SIGMA_spValorizacion_Detallada_Obtener_Result> Obtener_Valorizacion_Detallada(string sNNE, string sNROLOTE, string sSIGLA)
        {
            SIGMAEntities db = new SIGMAEntities();

            List<SIGMA_spValorizacion_Detallada_Obtener_Result> lista = db.SIGMA_spValorizacion_Detallada_Obtener(sNNE, sNROLOTE, sSIGLA).ToList();

            return lista;
        }

        public static List<SelectListItem> Obtener_Combo_Inventario()
        {
            SIGMAEntities db = new SIGMAEntities();

            List<ComboViewModel> lstINV = (from r in db.M18_Inventarios
                                           select new ComboViewModel
                                           {
                                               Id = r.Id_Inventario,
                                               Nombre = r.Codigo + " - " + r.Descripcion
                                           }).ToList();

            List<SelectListItem> items = lstINV.ConvertAll(r =>
            {
                return new SelectListItem
                {
                    Text = r.Nombre.ToString(),
                    Value = r.Id.ToString(),
                    Selected = false
                };
            });

            return items;
        }

        public static List<SelectListItem> Obtener_Combo_Origen()
        {
            SIGMAEntities db = new SIGMAEntities();

            List<ComboViewModel> lstORI = (from r in db.M18_OrigenGasto
                                           select new ComboViewModel
                                           {
                                               Id = r.Id_Origen,
                                               Nombre = r.Descripcion
                                           }).ToList();

            List<SelectListItem> items = lstORI.ConvertAll(r =>
            {
                return new SelectListItem
                {
                    Text = r.Nombre.ToString(),
                    Value = r.Id.ToString(),
                    Selected = false
                };
            });

            return items;
        }
    }
}