using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SICI_MVC.Models
{
    public class DALSICI
    {
        public static List<SelectListItem> Obtener_TipoBien()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "TODOS",
                    Value = "X",
                    Selected = true
                },
                new SelectListItem()
                {
                    Text = "CONSUMO",
                    Value = "C"
                },
                new SelectListItem()
                {
                    Text = "USO",
                    Value = "U"
                }
            };
        }

        public static List<SICI_spPatrimonio_Total_Obtener_Result> Obtener_Patrimonio_Total()
        {
            SICIEntities db = new SICIEntities();

            List<SICI_spPatrimonio_Total_Obtener_Result> lista = new List<SICI_spPatrimonio_Total_Obtener_Result>();

            lista = db.SICI_spPatrimonio_Total_Obtener().ToList();

            return lista;
        }

        public static List<SICI_spPatrimonio_Anualizado_Obtener_Result> Obtener_Patrimonio_Anualizado(string sAÑO_Desde, string sAÑO_Hasta)
        {
            SICIEntities db = new SICIEntities();

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

            List<SICI_spPatrimonio_Anualizado_Obtener_Result> lista = new List<SICI_spPatrimonio_Anualizado_Obtener_Result>();

            lista = db.SICI_spPatrimonio_Anualizado_Obtener(iAÑO_Desde, iAÑO_Hasta).ToList();

            return lista;
        }

        public static List<SICI_spAltas_Inventario_Obtener_Result> Obtener_Altas_Inventario(string sAÑO)
        {
            SICIEntities db = new SICIEntities();

            int iAÑO = 0;

            if (sAÑO.Trim() != "")
            {
                iAÑO = int.Parse(sAÑO);
            }

            List<SICI_spAltas_Inventario_Obtener_Result> lista = new List<SICI_spAltas_Inventario_Obtener_Result>();

            lista = db.SICI_spAltas_Inventario_Obtener(iAÑO).ToList();

            return lista;
        }

        public static List<SICI_spAmortizaciones_Inventario_Obtener_Result> Obtener_Amortizaciones_Inventario(string sAÑO)
        {
            SICIEntities db = new SICIEntities();

            int iAÑO = 0;

            if (sAÑO.Trim() != "")
            {
                iAÑO = int.Parse(sAÑO);
            }

            List<SICI_spAmortizaciones_Inventario_Obtener_Result> lista = new List<SICI_spAmortizaciones_Inventario_Obtener_Result>();

            lista = db.SICI_spAmortizaciones_Inventario_Obtener(iAÑO).ToList();

            return lista;
        }

        public static List<SICI_spBajas_Inventario_Obtener_Result> Obtener_Bajas_Inventario(string sAÑO)
        {
            SICIEntities db = new SICIEntities();

            int iAÑO = 0;

            if (sAÑO.Trim() != "")
            {
                iAÑO = int.Parse(sAÑO);
            }

            List<SICI_spBajas_Inventario_Obtener_Result> lista = new List<SICI_spBajas_Inventario_Obtener_Result>();

            lista = db.SICI_spBajas_Inventario_Obtener(iAÑO).ToList();

            return lista;
        }

        public static List<SICI_spInventario_Detallado_Obtener_Result> Obtener_Inventario_Detallado(string sAÑO)
        {
            SICIEntities db = new SICIEntities();

            List<SICI_spInventario_Detallado_Obtener_Result> lista = new List<SICI_spInventario_Detallado_Obtener_Result>();

            int iAÑO = int.Parse(sAÑO);

            lista = db.SICI_spInventario_Detallado_Obtener(iAÑO).ToList();

            return lista;
        }

        public static List<SICI.Baja_Anualizada> Obtener_Bajas_Anualizadas(string sAÑO_Desde, string sAÑO_Hasta)
        {
            SICIEntities db = new SICIEntities();

            List<SICI_spBajas_Anualizadas_Obtener_Result> lista = new List<SICI_spBajas_Anualizadas_Obtener_Result>();

            int iAÑO_Desde = int.Parse(sAÑO_Desde);
            int iAÑO_Hasta = int.Parse(sAÑO_Hasta);

            lista = db.SICI_spBajas_Anualizadas_Obtener(iAÑO_Desde, iAÑO_Hasta).ToList();

            List<SICI.Baja_Anualizada> listaRES = new List<SICI.Baja_Anualizada>();

            SICI.Baja_Anualizada objBaja = new SICI.Baja_Anualizada();

            string sSiglaTipo = String.Empty;

            int iIndice = 0;

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Sigla + lista[i].Tipo_Bien.Substring(0, 1) != sSiglaTipo)
                {
                    sSiglaTipo = lista[i].Sigla + lista[i].Tipo_Bien.Substring(0, 1);

                    iIndice = iIndice + 1;

                    objBaja.Id_Baja_Anualizada = iIndice;
                    objBaja.Sigla = lista[i].Sigla;
                    objBaja.Tipo_Bien = lista[i].Tipo_Bien;
                    objBaja.Descripcion_Inventario = lista[i].Descripcion_Inventario;

                    objBaja.Totales_Residuales = new decimal[6];

                    List<SICI_spBajas_Anualizadas_Obtener_Result> listaBAJA = new List<SICI_spBajas_Anualizadas_Obtener_Result>();

                    listaBAJA = (from a in lista
                                 where (a.Sigla == sSiglaTipo.Substring(0, 4))
                                    && (a.Tipo_Bien.Substring(0, 1) == sSiglaTipo.Substring(4, 1))
                                 select a).ToList<SICI_spBajas_Anualizadas_Obtener_Result>();

                    objBaja.Totales_Residuales[5] = 0;
                    for (int j = 0; j < listaBAJA.Count; j++)
                    {
                        objBaja.Totales_Residuales[j] = listaBAJA[j].Total_Residual;
                        objBaja.Totales_Residuales[5] = objBaja.Totales_Residuales[5] + listaBAJA[j].Total_Residual;
                    }

                    listaRES.Add(objBaja);

                    objBaja = new SICI.Baja_Anualizada();
                }
            }

            return listaRES;
        }

        public static List<SICI.Amortizacion_Detallada> Obtener_Amortizaciones_Detalladas(string sAÑO_Desde, string sAÑO_Hasta)
        {
            SICIEntities db = new SICIEntities();

            List<SICI_spAmortizaciones_Detalladas_Obtener_Result> lista = new List<SICI_spAmortizaciones_Detalladas_Obtener_Result>();

            int iAÑO_Desde = int.Parse(sAÑO_Desde);
            int iAÑO_Hasta = int.Parse(sAÑO_Hasta);

            lista = db.SICI_spAmortizaciones_Detalladas_Obtener(iAÑO_Desde, iAÑO_Hasta).ToList();

            List<SICI.Amortizacion_Detallada> listaRES = new List<SICI.Amortizacion_Detallada>();

            SICI.Amortizacion_Detallada objAmort = new SICI.Amortizacion_Detallada();

            string sSiglaTipo = String.Empty;

            int iIndice = 0;

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Sigla + lista[i].Tipo_Bien.Substring(0,1) != sSiglaTipo)
                {
                    sSiglaTipo = lista[i].Sigla + lista[i].Tipo_Bien.Substring(0, 1);

                    iIndice = iIndice + 1;

                    objAmort.Id_Amortizacion_Detallada = iIndice;
                    objAmort.Sigla = lista[i].Sigla;
                    objAmort.Tipo_Bien = lista[i].Tipo_Bien;
                    objAmort.Descripcion_Inventario = lista[i].Descripcion_Inventario;

                    objAmort.Amortizaciones = new decimal[6];

                    List<SICI_spAmortizaciones_Detalladas_Obtener_Result> listaAMO = new List<SICI_spAmortizaciones_Detalladas_Obtener_Result>();

                    listaAMO = (from a in lista
                                where (a.Sigla == sSiglaTipo.Substring(0,4))
                                   && (a.Tipo_Bien.Substring(0,1) == sSiglaTipo.Substring(4,1))
                                select a).ToList<SICI_spAmortizaciones_Detalladas_Obtener_Result>();

                    for (int j = 0; j < listaAMO.Count; j++)
                    {
                         objAmort.Amortizaciones[j] = listaAMO[j].Amortizacion_Anual;
                    }

                    listaRES.Add(objAmort);

                    objAmort = new SICI.Amortizacion_Detallada();
                }
            }
            return listaRES;
        }
    }
}