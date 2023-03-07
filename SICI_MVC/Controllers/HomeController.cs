using SICI_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SICI_MVC.Models.SIGMA;
using SICI_MVC.Models.SICI;

namespace SICI_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Principal_DGMN()
        {
            ViewBag.Message = "Menú Principal DGMN";

            return View();
        }

        public ActionResult Patrimonio_Total(string Tipo_Bien = "")
        {
            ViewBag.Message = "Patrimonio Total";

            List<SICI_spPatrimonio_Total_Obtener_Result> lista = DALSICI.Obtener_Patrimonio_Total();

            var iTOTAL_VALORIZADO = lista.Sum(x => x.Total_Valorizado);

            ViewBag.Totalizado = "PATRIMONIO TOTAL DE LA ARMADA ARGENTINA ==> " + iTOTAL_VALORIZADO.ToString();

            return View(lista);
        }

        public ActionResult Inventario_Detallado(string txtAÑO = "")
        {
            ViewBag.Message = "Inventario Detallado";

            List<SICI_spInventario_Detallado_Obtener_Result> lista = new List<SICI_spInventario_Detallado_Obtener_Result>();

            if (txtAÑO.Trim() != "")
            {
                if (txtAÑO.Trim().Length != 4)
                {
                    ViewBag.Error = "LONGITUD DE AÑO DE CONSULTA INCORRECTO - VERIFIQUE";

                    lista = null;
                }
                else
                {
                    int iAÑO = int.Parse(txtAÑO);

                    if (iAÑO >= DateTime.Today.Year)
                    {
                        ViewBag.Error = "AÑO de CONSULTA debe ser MENOR que el AÑO ACTUAL - VERIFIQUE";

                        lista = null;
                    }
                    else
                    {
                        lista = DALSICI.Obtener_Inventario_Detallado(txtAÑO).ToList();

                        if (lista.Count == 0)
                        {
                            ViewBag.Resultado = "NO SE ENCONTRO INFORMACION PARA EL AÑO DE CONSULTA INGRESADO";

                            lista = null;
                        }
                        else
                        {
                            var iTOTAL_AÑO = lista.Sum(x => x.Total_General_Año);

                            ViewBag.Resultado = "TOTAL GENERAL AL 31/12/" + txtAÑO + " ==> " + iTOTAL_AÑO.ToString();
                        }
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE UN AÑO DE CONSULTA PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            ViewBag.Año = txtAÑO.Trim();

            return View(lista);
        }

        public ActionResult Bajas_Inventario(string txtAÑO_ALTA = "")
        {
            ViewBag.Message = "Bajas Inventario";

            List<SICI_spBajas_Inventario_Obtener_Result> lista = new List<SICI_spBajas_Inventario_Obtener_Result>();

            if (txtAÑO_ALTA.Trim() != "")
            {
                if (txtAÑO_ALTA.Trim().Length != 4)
                {
                    ViewBag.Error = "LONGITUD DE AÑO DE ALTA INCORRECTO - VERIFIQUE";

                    lista = null;
                }
                else
                {
                    if (int.Parse(txtAÑO_ALTA) > DateTime.Today.Year)
                    {
                        ViewBag.Error = "AÑO DE ALTA ES MAYOR QUE AÑO ACTUAL - VERIFIQUE";

                        lista = null;
                    }
                    else
                    {
                        lista = DALSICI.Obtener_Bajas_Inventario(txtAÑO_ALTA).ToList();

                        if (lista.Count == 0)
                        {
                            ViewBag.Resultado = "NO SE ENCONTRO INFORMACION de BAJAS PRODUCIDAS PARA LOS DISTINTOS INVENTARIOS de la ARMADA ARGENTINA para el AÑO INGRESADO";

                            lista = null;
                        }
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE UN AÑO DE ALTA PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            return View(lista);
        }

        public ActionResult Altas_Inventario(string txtAÑO = "", string cboTIPOBIEN = "X")
        {
            ViewBag.Message = "Altas Inventario";

            ViewBag.MiListado = DALSICI.Obtener_TipoBien();

            List<SICI_spAltas_Inventario_Obtener_Result> lista = new List<SICI_spAltas_Inventario_Obtener_Result>();

            if (txtAÑO.Trim() != "")
            {
                if (txtAÑO.Trim().Length != 4)
                {
                    ViewBag.Error = "LONGITUD DE AÑO DE ALTA INCORRECTO - VERIFIQUE";

                    lista = null;
                }
                else
                {
                    lista = DALSICI.Obtener_Altas_Inventario(txtAÑO).ToList();

                    lista = (from a in lista
                             where (a.Tipo_Bien.Substring(0, 1) == cboTIPOBIEN || cboTIPOBIEN == "X")
                             select a).ToList();

                    if (lista.Count == 0)
                    {
                        ViewBag.Resultado = "NO SE ENCONTRO INFORMACION PARA EL AÑO DE ALTA INGRESADO";

                        lista = null;
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE UN AÑO DE ALTA PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            return View(lista);
        }

        public ActionResult Amortizaciones_Inventario(string txtAÑO = "")
        {
            ViewBag.Message = "Amortizaciones Inventario";

            List<SICI_spAmortizaciones_Inventario_Obtener_Result> lista = new List<SICI_spAmortizaciones_Inventario_Obtener_Result>();

            if (txtAÑO.Trim() != "")
            {
                if (txtAÑO.Trim().Length != 4)
                {
                    ViewBag.Error = "LONGITUD DE AÑO DE ALTA INCORRECTO - VERIFIQUE";

                    lista = null;
                }
                else
                {
                    lista = DALSICI.Obtener_Amortizaciones_Inventario(txtAÑO).ToList();

                    if (lista.Count == 0)
                    {
                        ViewBag.Resultado = "NO SE ENCONTRO INFORMACION PARA EL AÑO DE ALTA INGRESADO";

                        lista = null;
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE UN AÑO DE ALTA PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            return View(lista);
        }

        public ActionResult Bajas_Anualizadas(string txtAÑO_DESDE = "", string txtAÑO_HASTA = "")
        {
            ViewBag.Message = "Bajas Anualizadas";

            List<Baja_Anualizada> lista = new List<Baja_Anualizada>();

            bool bHayError = false;

            int iAÑO_Desde = 0;
            int iAÑO_Hasta = 0;

            if (txtAÑO_DESDE.Trim() != "")
            {
                if (txtAÑO_DESDE.Length != 4)
                {
                    ViewBag.Error = "LONGITUD DE AÑO DESDE INCORRECTO - VERIFIQUE";

                    lista = null;

                    bHayError = true;
                }
            }
            else
            {
                ViewBag.Mensaje = "DEBE INGRESAR AÑO DESDE PARA INICIAR LA BUSQUEDA";

                lista = null;

                bHayError = true;
            }

            if (!bHayError)
            {
                if (txtAÑO_HASTA.Trim() != "")
                {
                    if (txtAÑO_HASTA.Length != 4)
                    {
                        ViewBag.Error = "LONGITUD DE AÑO HASTA INCORRECTO - VERIFIQUE";

                        lista = null;

                        bHayError = true;
                    }
                }
                else
                {
                    ViewBag.Mensaje = "DEBE INGRESAR AÑO HASTA PARA INICIAR LA BUSQUEDA";

                    lista = null;

                    bHayError = true;
                }
            }

            if (!bHayError)
            {
                iAÑO_Desde = int.Parse(txtAÑO_DESDE);
                iAÑO_Hasta = int.Parse(txtAÑO_HASTA);

                if (iAÑO_Desde > iAÑO_Hasta)
                {
                    ViewBag.Error = "AÑO DESDE DEBE SER MENOR QUE AÑO HASTA - VERIFIQUE";

                    lista = null;

                    bHayError = true;
                }
                else
                {
                    if (iAÑO_Hasta - iAÑO_Desde != 4)
                    {
                        ViewBag.Error = "INTERVALO DE AÑOS DE BUSQUEDA DEBE SER IGUAL A CINCO - VERIFIQUE";

                        lista = null;

                        bHayError = true;
                    }
                    else
                    {
                        if (iAÑO_Hasta > DateTime.Today.Year)
                        {
                            ViewBag.Error = "AÑO HASTA ES MAYOR QUE AÑO ACTUAL - VERIFIQUE";

                            lista = null;

                            bHayError = true;
                        }
                    }
                }
            }

            if (!bHayError)
            {
                lista = DALSICI.Obtener_Bajas_Anualizadas(txtAÑO_DESDE, txtAÑO_HASTA);

                if (lista.Count == 0)
                {
                    ViewBag.Resultado = "NO SE ENCONTRO INFORMACION DE LAS BAJAS ANUALES DE LOS INVENTARIOS DE LA ARMADA ARGENTINA para el PERIODO indicado";

                    lista = null;
                }
                else
                {
                    string[] Años;
                    Años = new string[5];

                    for (int i = 0; i < 5; i++)
                    {
                        Años[i] = (iAÑO_Desde + i).ToString();
                    }

                    ViewBag.Años = Años;
                }
            }
            
            return View(lista);
        }
        public ActionResult Amortizaciones_Detalladas(string cboTIPOBIEN = "X")
        {
            ViewBag.Message = "Amortizaciones Detalladas";

            ViewBag.MiListado = DALSICI.Obtener_TipoBien();

            List<Amortizacion_Detallada> lista = new List<Amortizacion_Detallada>();

            string sAÑO_Desde = DateTime.Today.Year.ToString();
            string sAÑO_Hasta = (DateTime.Today.Year + 5).ToString();

            lista = DALSICI.Obtener_Amortizaciones_Detalladas(sAÑO_Desde, sAÑO_Hasta);

            if (lista.Count == 0)
            {
                ViewBag.Resultado = "NO SE ENCONTRO INFORMACION DE AMORTIZACIONES ANUALES DE LOS INVENTARIOS DE LA ARMADA ARGENTINA";

                lista = null;
            }
            else
            {
                lista = (from a in lista
                         where (a.Tipo_Bien.Substring(0, 1) == cboTIPOBIEN || cboTIPOBIEN == "X")
                         select a).ToList();
            }

            string[] Años;
            Años = new string[5];

            int iAñoInicial = DateTime.Today.Year;

            for (int i = 0; i < 5; i++)
            {
                Años[i] = (iAñoInicial + i + 1).ToString();
            }

            ViewBag.Años = Años;

            return View(lista);
        }
        public ActionResult Patrimonio_Anualizado(int pagina = 1, string txtAÑO_DESDE = "", string txtAÑO_HASTA = "")
        {
            ViewBag.Message = "Patrimonio Anualizado";

            List<SICI_spPatrimonio_Anualizado_Obtener_Result> lista = new List<SICI_spPatrimonio_Anualizado_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 8;

            if (txtAÑO_DESDE.Trim() != "" && txtAÑO_HASTA.Trim() != "")
            {
                if (txtAÑO_DESDE.Trim().Length != 4)
                {
                    ViewBag.Error = "LONGITUD DE AÑO DESDE INCORRECTO - VERIFIQUE";

                    lista = null;
                }
                else
                {
                    if (txtAÑO_HASTA.Trim().Length != 4)
                    {
                        ViewBag.Error = "LONGITUD DE AÑO HASTA INCORRECTO - VERIFIQUE";

                        lista = null;
                    }
                    else
                    {
                        lista = DALSICI.Obtener_Patrimonio_Anualizado(txtAÑO_DESDE, txtAÑO_HASTA).ToList();

                        totalDeRegistros = lista.Count();

                        lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                        if (lista.Count == 0)
                        {
                            ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU BUSQUEDA";

                            lista = null;
                        }
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE UN RANGO DE AÑOS PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            var modelo = new Patrimonio_Anualizado_Pagina();

            modelo.Patrimonio_Anualizado = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtAÑO_DESDE"] = txtAÑO_DESDE;
            modelo.ValoresQueryString["txtAÑO_HASTA"] = txtAÑO_HASTA;

            return View(modelo);
        }
        public ActionResult Peliculas_Pais(int pagina = 1, string txtPAIS = "", string txtAÑO = "", string txtFECHA_DESDE = "", string txtFECHA_HASTA = "")
        {
            List<SIGMA_spPeliculas_Seleccionar_Result> lista = DALSIGMA.Obtener_Peliculas(txtPAIS, txtAÑO, txtFECHA_DESDE, txtFECHA_HASTA);

            var totalDeRegistros = lista.Count();

            var cantidadRegistrosPorPagina = 6;

            lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

            var modelo = new Peliculas_Pagina();

            modelo.Peliculas = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtPAIS"] = txtPAIS;
            modelo.ValoresQueryString["txtAÑO"] = txtAÑO;
            modelo.ValoresQueryString["txtFECHA_DESDE"] = txtFECHA_DESDE;
            modelo.ValoresQueryString["txtFECHA_HASTA"] = txtFECHA_HASTA;

            return View(modelo);
        }

        public ActionResult Totales_Destino(int pagina = 1, string txtZona = "", string txtSigla = "")
        {
            ViewBag.Message = "Totales por Destino";

            List<SIGMA_spTotales_Destino_Obtener_Result> lista = DALSIGMA.Obtener_Totales_Destino(txtZona, txtSigla).ToList();

            var iTOTAL_VALORIZADO = lista.Sum(x => x.Total_Valorizado);

            var totalDeRegistros = lista.Count();

            var cantidadRegistrosPorPagina = 6;

            lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

            if (lista.Count > 0)
            {
                ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
            }
            else
            {
                ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU CRITERIO DE BUSQUEDA";

                lista = null;
            }

            var modelo = new Totales_Destino_Pagina();

            modelo.Totales_Destino = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtZona"] = txtZona;
            modelo.ValoresQueryString["txtSigla"] = txtSigla;

            return View(modelo);
        }

        public ActionResult Totales_Cargo_Destino(int pagina = 1, string txtSigla = "", string txtCargoDestino = "")
        {
            ViewBag.Message = "Totales por Cargo Destino";

            List<SIGMA_spTotales_Cargo_Destino_Obtener_Result> lista = new List<SIGMA_spTotales_Cargo_Destino_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 6;

            if (txtSigla.Trim() != "")
            {
                lista = DALSIGMA.Obtener_Totales_Cargo_Destino(txtSigla, txtCargoDestino).ToList();

                var iTOTAL_VALORIZADO = lista.Sum(x => x.Total_Valorizado);

                totalDeRegistros = lista.Count();

                lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                if (lista.Count > 0)
                {
                    ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                }
                else
                {
                    ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU CRITERIO DE BUSQUEDA";

                    lista = null;
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE LA SIGLA DE DESTINO PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            var modelo = new Totales_Cargo_Destino_Pagina();

            modelo.Totales_Cargo_Destino = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtSigla"] = txtSigla;
            modelo.ValoresQueryString["txtCargoDestino"] = txtCargoDestino;

            return View(modelo);
        }
        public ActionResult Totales_Cargo_Efecto(int pagina = 1, string txtCargoEfecto = "", string txtSigla = "", string txtCargoDestino = "")
        {
            ViewBag.Message = "Totales por Cargo Efecto";

            List<SIGMA_spTotales_Cargo_Efecto_Obtener_Result> lista = new List<SIGMA_spTotales_Cargo_Efecto_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 6;

            if (txtCargoEfecto.Trim() != "" || txtSigla.Trim() != "")
            {
                lista = DALSIGMA.Obtener_Totales_Cargo_Efecto(txtCargoEfecto, txtSigla, txtCargoDestino).ToList();

                var iTOTAL_VALORIZADO = lista.Sum(x => x.Total_Valorizado);

                totalDeRegistros = lista.Count();

                lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                if (lista.Count > 0)
                {
                    ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                }
                else
                {
                    ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU CRITERIO DE BUSQUEDA";

                    lista = null;
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE EL CODIGO DE CARGO EFECTO O BIEN LA SIGLA DE DESTINO PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            var modelo = new Totales_Cargo_Efecto_Pagina();

            modelo.Totales_Cargo_Efecto = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtCargoEfecto"] = txtCargoEfecto;
            modelo.ValoresQueryString["txtSigla"] = txtSigla;
            modelo.ValoresQueryString["txtCargoDestino"] = txtCargoDestino;

            return View(modelo);
        }

        public ActionResult Totales_Efecto(int pagina = 1, string txtNNE = "", string txtSigla = "", string txtCargoDestino = "", string txtCargoEfecto = "")
        {
            ViewBag.Message = "Totales por Efecto";

            List<SIGMA_spTotales_Efecto_Obtener_Result> lista = new List<SIGMA_spTotales_Efecto_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 6;

            if (txtNNE.Trim() != "" || txtSigla.Trim() != "" || txtCargoDestino.Trim() != "" || txtCargoEfecto.Trim() != "")
            {
                lista = DALSIGMA.Obtener_Totales_Efecto(txtNNE, txtSigla, txtCargoDestino, txtCargoEfecto).ToList();

                var iTOTAL_VALORIZADO = lista.Sum(x => x.Total_Valorizado);

                totalDeRegistros = lista.Count();

                lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                if (lista.Count > 0)
                {
                    ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                }
                else
                {
                    ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU CRITERIO DE BUSQUEDA";

                    lista = null;
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE AL MENOS UN ARGUMENTO PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            var modelo = new Totales_Efecto_Pagina();

            modelo.Totales_Efecto = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtNNE"] = txtNNE;
            modelo.ValoresQueryString["txtSigla"] = txtSigla;
            modelo.ValoresQueryString["txtCargoDestino"] = txtCargoDestino;
            modelo.ValoresQueryString["txtCargoEfecto"] = txtCargoEfecto;

            return View(modelo);
        }

        public ActionResult Efectos_Amortizados(int pagina = 1, string txtFECHA_DESDE = "", string txtFECHA_HASTA = "")
        {
            ViewBag.Message = "Efectos Amortizados";

            List<SIGMA_spEfectos_Amortizados_Obtener_Result> lista = new List<SIGMA_spEfectos_Amortizados_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 6;

            bool HayError = false;

            if (txtFECHA_DESDE.Trim() == "" && txtFECHA_HASTA.Trim() == "")
            {
                ViewBag.Mensaje = "INGRESE UN INTERVALO DE FECHAS DE ALTA PARA INICIAR LA BUSQUEDA";

                lista = null;

                HayError = true;
            }
            else
            {
                if (txtFECHA_DESDE.Trim() == "")
                {
                    ViewBag.Mensaje = "INGRESE LA FECHA DE ALTA DESDE PARA INICIAR LA BUSQUEDA";

                    lista = null;

                    HayError = true;
                }
                else
                {
                    if (txtFECHA_DESDE.Trim().Length > 10)
                    {
                        ViewBag.Error = "FORMATO DE FECHA DE ALTA DESDE INCORRECTO - VERIFIQUE";

                        lista = null;

                        HayError = true;
                    }
                    else
                    {
                        if (txtFECHA_HASTA.Trim() == "")
                        {
                            ViewBag.Mensaje = "INGRESE LA FECHA DE ALTA HASTA PARA INICIAR LA BUSQUEDA";

                            lista = null;

                            HayError = true;
                        }
                        else
                        {
                            if (txtFECHA_HASTA.Trim().Length > 10)
                            {
                                ViewBag.Error = "FORMATO DE FECHA DE ALTA HASTA INCORRECTO - VERIFIQUE";

                                lista = null;

                                HayError = true;
                            }
                        }
                    }
                }
            }

            if (!HayError)
            {
                lista = DALSIGMA.Obtener_Efectos_Amortizados(txtFECHA_DESDE, txtFECHA_HASTA).ToList();

                var iTOTAL_VALORIZADO = lista.Sum(x => x.Valor_Residual);

                totalDeRegistros = lista.Count();

                lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                if (lista.Count > 0)
                {
                    ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                }
                else
                {
                    ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU BUSQUEDA";

                    lista = null;
                }
            }

            var modelo = new Efectos_Amortizados_Pagina();

            modelo.Efectos_Amortizados = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtFECHA_DESDE"] = txtFECHA_DESDE;
            modelo.ValoresQueryString["txtFECHA_HASTA"] = txtFECHA_HASTA;

            return View(modelo);
        }

        public ActionResult Valorizacion_Detallada(int pagina = 1, string txtNNE = "", string txtNROLOTE = "", string txtSIGLA = "")
        {
            ViewBag.Message = "Valorización Detallada";

            List<SIGMA_spValorizacion_Detallada_Obtener_Result> lista = new List<SIGMA_spValorizacion_Detallada_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 6;

            if (txtNNE.Trim() != "")
            {
                lista = DALSIGMA.Obtener_Valorizacion_Detallada(txtNNE, txtNROLOTE, txtSIGLA).ToList();

                var iTOTAL_VALORIZADO = lista.Sum(x => x.Valor_Actual);

                totalDeRegistros = lista.Count();

                lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                if (lista.Count > 0)
                {
                    ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                }
                else
                {
                    ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU BUSQUEDA";

                    lista = null;
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE UN N.N.E. VALIDO PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            var modelo = new Valorizacion_Detallada_Pagina();

            modelo.Valorizacion_Detallada = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtNNE"] = txtNNE;
            modelo.ValoresQueryString["txtNROLOTE"] = txtNROLOTE;
            modelo.ValoresQueryString["txtSIGLA"] = txtSIGLA;

            return View(modelo);
        }

        public ActionResult Despiece_Valorizado(int pagina = 1, string txtNNE = "", string txtNROINVENTARIO = "", string txtNROSERIEEJ = "")
        {
            ViewBag.Message = "Despiece Valorizado";

            List<SIGMA_spDespiece_Valorizado_Obtener_Result> lista = new List<SIGMA_spDespiece_Valorizado_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 6;

            if (txtNNE.Trim() != "")
            {
                if (txtNROINVENTARIO.Trim() != "" || txtNROSERIEEJ.Trim() != "")
                {
                    lista = DALSIGMA.Obtener_Despiece_Valorizado(txtNNE, txtNROINVENTARIO, txtNROSERIEEJ).ToList();

                    var iTOTAL_VALORIZADO = lista.Sum(x => x.Valor_Actual);

                    totalDeRegistros = lista.Count();

                    lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                    if (lista.Count > 0)
                    {
                        ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                    }
                    else
                    {
                        ViewBag.Resultado = "NO SE ENCONTRARON PIEZAS PARA SU BUSQUEDA";

                        lista = null;
                    }
                }
                else
                {
                    ViewBag.Mensaje = "INGRESE EL NUMERO DE INVENTARIO O BIEN EL NUMERO DE SERIE-EJEMPLAR DEL EFECTO PRIMARIO CORRESPONDIENTE";

                    lista = null;
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE EL N.N.E. DEL EFECTO PRIMARIO PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            var modelo = new Despiece_Valorizado_Pagina();

            modelo.Despiece_Valorizado = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();          
            modelo.ValoresQueryString["txtNNE"] = txtNNE;
            modelo.ValoresQueryString["txtNROINVENTARIO"] = txtNROINVENTARIO;
            modelo.ValoresQueryString["txtNROSERIEEJ"] = txtNROSERIEEJ;

            return View(modelo);
        }

        public ActionResult Altas_Generales(int pagina = 1, string cboORIGEN = "", string txtFECHA_DESDE = "", string txtFECHA_HASTA = "")
        {
            ViewBag.Message = "Altas Generales";

            List<SIGMA_spAltas_Generales_Obtener_Result> lista = new List<SIGMA_spAltas_Generales_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 5;

            if (txtFECHA_DESDE.Trim() != "" && txtFECHA_HASTA.Trim() != "")
            {
                if (txtFECHA_DESDE.Trim().Length > 10)
                {
                    ViewBag.Error = "FORMATO DE FECHA DE ALTA DESDE INCORRECTO - VERIFIQUE";

                    lista = null;
                }
                else
                {
                    if (txtFECHA_HASTA.Trim().Length > 10)
                    {
                        ViewBag.Error = "FORMATO DE FECHA DE ALTA HASTA INCORRECTO - VERIFIQUE";

                        lista = null;
                    }
                    else
                    {
                        lista = DALSIGMA.Obtener_Altas_Generales(cboORIGEN, txtFECHA_DESDE, txtFECHA_HASTA).ToList();

                        var iTOTAL_VALORIZADO = lista.Sum(x => x.Total_Valorizado);

                        totalDeRegistros = lista.Count();

                        lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                        if (lista.Count > 0)
                        {
                            ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                        }
                        else
                        {
                            ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU BUSQUEDA";

                            lista = null;
                        }
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE UN RANGO DE FECHAS DE ALTA PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            ViewBag.items = DALSIGMA.Obtener_Combo_Origen();

            var modelo = new Altas_Generales_Pagina();

            modelo.Altas_Generales = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["cboORIGEN"] = cboORIGEN;
            modelo.ValoresQueryString["txtFECHA_DESDE"] = txtFECHA_DESDE;
            modelo.ValoresQueryString["txtFECHA_HASTA"] = txtFECHA_HASTA;

            return View(modelo);
        }

        public ActionResult Altas_Detalladas(int pagina = 1, string txtNNE = "", string txtFECHA_DESDE = "", string txtFECHA_HASTA = "")
        {
            ViewBag.Message = "Altas Detalladas";

            List<SIGMA_spAltas_Detalladas_Obtener_Result> lista = new List<SIGMA_spAltas_Detalladas_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 6;

            bool HayError = false;

            if (txtNNE.Trim() == "")
            {
                ViewBag.Mensaje = "INGRESE UN N.N.E. VALIDO PARA INICIAR LA BUSQUEDA";

                lista = null;
            }
            else
            {
                if (txtFECHA_DESDE.Trim() != "")
                {
                    if (txtFECHA_DESDE.Trim().Length > 10)
                    {
                        ViewBag.Error = "FORMATO DE FECHA DE ALTA DESDE INCORRECTO - VERIFIQUE";

                        lista = null;

                        HayError = true;
                    }
                }
                if (txtFECHA_HASTA.Trim() != "")
                {
                    if (txtFECHA_HASTA.Trim().Length > 10)
                    {
                        ViewBag.Error = "FORMATO DE FECHA DE ALTA HASTA INCORRECTO - VERIFIQUE";

                        lista = null;

                        HayError = true;
                    }
                }
            }

            if (txtNNE.Trim() != "" && !HayError)
            {
                lista = DALSIGMA.Obtener_Altas_Detalladas(txtNNE, txtFECHA_DESDE, txtFECHA_HASTA).ToList();

                var iTOTAL_VALORIZADO = lista.Sum(x => x.Valor_Actual);

                totalDeRegistros = lista.Count();

                lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                if (lista.Count > 0)
                {
                    ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                }
                else
                {
                    ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU BUSQUEDA";

                    lista = null;
                }
            }

            var modelo = new Altas_Detalladas_Pagina();

            modelo.Altas_Detalladas = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtNNE"] = txtNNE;
            modelo.ValoresQueryString["txtFECHA_DESDE"] = txtFECHA_DESDE;
            modelo.ValoresQueryString["txtFECHA_HASTA"] = txtFECHA_HASTA;

            return View(modelo);
        }

        public ActionResult Altas_Anuales(int pagina = 1, string txtAÑO_DESDE = "", string txtAÑO_HASTA = "")
        {
            ViewBag.Message = "Altas Anuales";

            List<SIGMA_spAltas_Anuales_Obtener_Result> lista = new List<SIGMA_spAltas_Anuales_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 6;

            bool bHayError = false;

            if (txtAÑO_DESDE.Trim() != "")
            {
                if (txtAÑO_DESDE.Length != 4)
                {
                    ViewBag.Error = "LONGITUD DE AÑO DESDE INCORRECTO - VERIFIQUE";

                    lista = null;

                    bHayError = true;
                }
            }
            if (txtAÑO_HASTA.Trim() != "")
            {
                if (txtAÑO_HASTA.Length != 4)
                {
                    ViewBag.Error = "LONGITUD DE AÑO HASTA INCORRECTO - VERIFIQUE";

                    lista = null;

                    bHayError = true;
                }
            }

            if (!bHayError)
            {
                lista = DALSIGMA.Obtener_Altas_Anuales(txtAÑO_DESDE, txtAÑO_HASTA).ToList();

                var iTOTAL_VALORIZADO = lista.Sum(x => x.Total_Valorizado_General);

                totalDeRegistros = lista.Count();

                lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                if (lista.Count > 0)
                {
                    ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                }
                else
                {
                    ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU BUSQUEDA";

                    lista = null;
                }
            }

            var modelo = new Altas_Anuales_Pagina();

            modelo.Altas_Anuales = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtAÑO_DESDE"] = txtAÑO_DESDE;
            modelo.ValoresQueryString["txtAÑO_HASTA"] = txtAÑO_HASTA;

            return View(modelo);
        }

        public ActionResult Amortizaciones_Anuales(int pagina = 1, string txtFECHA_DESDE = "", string txtFECHA_HASTA = "", string txtNROLOTE = "", string txtNNE = "")
        {
            ViewBag.Message = "Amortizaciones Anuales";

            List<SIGMA_spAmortizaciones_Anuales_Obtener_Result> lista = new List<SIGMA_spAmortizaciones_Anuales_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 5;

            if (txtFECHA_DESDE.Trim() != "" && txtFECHA_HASTA.Trim() != "")
            {
                if (txtFECHA_DESDE.Trim().Length > 10)
                {
                    ViewBag.Error = "FORMATO DE FECHA DE ALTA DESDE INCORRECTO - VERIFIQUE";

                    lista = null;
                }
                else
                {
                    if (txtFECHA_HASTA.Trim().Length > 10)
                    {
                        ViewBag.Error = "FORMATO DE FECHA DE ALTA HASTA INCORRECTO - VERIFIQUE";

                        lista = null;
                    }
                    else
                    {
                        lista = DALSIGMA.Obtener_Amortizaciones_Anuales(txtFECHA_DESDE, txtFECHA_HASTA, txtNROLOTE, txtNNE).ToList();

                        var iTOTAL_VALORIZADO = lista.Sum(x => x.Valor_Residual);

                        totalDeRegistros = lista.Count();

                        lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                        if (lista.Count > 0)
                        {
                            ViewBag.Resultado = ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                        }
                        else
                        {
                            ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU BUSQUEDA";

                            lista = null;
                        }
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE UN RANGO DE FECHAS DE ALTA DE LOTE PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            var modelo = new Amortizaciones_Anuales_Pagina();

            modelo.Amortizaciones_Anuales = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtFECHA_DESDE"] = txtFECHA_DESDE;
            modelo.ValoresQueryString["txtFECHA_HASTA"] = txtFECHA_HASTA;
            modelo.ValoresQueryString["txtNROLOTE"] = txtNROLOTE;
            modelo.ValoresQueryString["txtNNE"] = txtNNE;

            return View(modelo);
        }

        public ActionResult Descargos_Valorizados(int pagina = 1, string txtFECHA_DESDE = "", string txtFECHA_HASTA = "", string txtSIGLA = "", string txtNNE = "")
        {
            ViewBag.Message = "Descargos Valorizados";

            List<SIGMA_spDescargos_Valorizados_Obtener_Result> lista = new List<SIGMA_spDescargos_Valorizados_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 4;

            if (txtFECHA_DESDE.Trim() != "" && txtFECHA_HASTA.Trim() != "")
            {
                if (txtFECHA_DESDE.Trim().Length > 10)
                {
                    ViewBag.Error = "FORMATO DE FECHA DE ALTA DESDE INCORRECTO - VERIFIQUE";

                    lista = null;
                }
                else
                {
                    if (txtFECHA_HASTA.Trim().Length > 10)
                    {
                        ViewBag.Error = "FORMATO DE FECHA DE ALTA HASTA INCORRECTO - VERIFIQUE";

                        lista = null;
                    }
                    else
                    {
                        lista = DALSIGMA.Obtener_Descargos_Valorizados(txtFECHA_DESDE, txtFECHA_HASTA, txtSIGLA, txtNNE).ToList();

                        var iTOTAL_VALORIZADO = lista.Sum(x => x.Valor_Actual);

                        totalDeRegistros = lista.Count();

                        lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                        if (lista.Count > 0)
                        {
                            ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                        }
                        else
                        {
                            ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU BUSQUEDA";

                            lista = null;
                        }
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE UN RANGO DE FECHAS DE ALTA PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            var modelo = new Descargos_Valorizados_Pagina();

            modelo.Descargos_Valorizados = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtFECHA_DESDE"] = txtFECHA_DESDE;
            modelo.ValoresQueryString["txtFECHA_HASTA"] = txtFECHA_HASTA;
            modelo.ValoresQueryString["txtSIGLA"] = txtSIGLA;
            modelo.ValoresQueryString["txtNNE"] = txtNNE;

            return View(modelo);
        }

        public ActionResult Lotes_Destino(int pagina = 1, string txtFECHA_DESDE = "", string txtFECHA_HASTA = "", string txtSIGLA = "")
        {
            ViewBag.Message = "Lotes Destino";

            List<SIGMA_spLotes_Destino_Obtener_Result> lista = new List<SIGMA_spLotes_Destino_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 6;

            if (txtFECHA_DESDE.Trim() != "" && txtFECHA_HASTA.Trim() != "")
            {
                if (txtFECHA_DESDE.Trim().Length > 10)
                {
                    ViewBag.Error = "FORMATO DE FECHA DE ALTA DESDE INCORRECTO - VERIFIQUE";

                    lista = null;
                }
                else
                {
                    if (txtFECHA_HASTA.Trim().Length > 10)
                    {
                        ViewBag.Error = "FORMATO DE FECHA DE ALTA HASTA INCORRECTO - VERIFIQUE";

                        lista = null;
                    }
                    else
                    {
                        lista = DALSIGMA.Obtener_Lotes_Destino(txtFECHA_DESDE, txtFECHA_HASTA, txtSIGLA).ToList();

                        var iTOTAL_VALORIZADO = lista.Sum(x => x.Total_Valorizado_General);

                        totalDeRegistros = lista.Count();

                        lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                        if (lista.Count > 0)
                        {
                            ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                        }
                        else
                        {
                            ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU BUSQUEDA";

                            lista = null;
                        }
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE UN RANGO DE FECHAS DE ALTA DE LOTES PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            var modelo = new Lotes_Destino_Pagina();

            modelo.Lotes_Destino = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtFECHA_DESDE"] = txtFECHA_DESDE;
            modelo.ValoresQueryString["txtFECHA_HASTA"] = txtFECHA_HASTA;
            modelo.ValoresQueryString["txtSIGLA"] = txtSIGLA;

            return View(modelo);
        }

        public ActionResult Lotes_Inventario(int pagina = 1, string txtFECHA_DESDE = "", string txtFECHA_HASTA = "", string cboInventario = "")
        {
            ViewBag.Message = "Lotes Inventario";

            List<SIGMA_spLotes_Inventario_Obtener_Result> lista = new List<SIGMA_spLotes_Inventario_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 6;

            if (txtFECHA_DESDE.Trim() != "" && txtFECHA_HASTA.Trim() != "")
            {
                if (txtFECHA_DESDE.Trim().Length > 10)
                {
                    ViewBag.Error = "FORMATO DE FECHA DE ALTA DESDE INCORRECTO - VERIFIQUE";

                    lista = null;
                }
                else
                {
                    if (txtFECHA_HASTA.Trim().Length > 10)
                    {
                        ViewBag.Error = "FORMATO DE FECHA DE ALTA HASTA INCORRECTO - VERIFIQUE";

                        lista = null;
                    }
                    else
                    {
                        lista = DALSIGMA.Obtener_Lotes_Inventario(txtFECHA_DESDE, txtFECHA_HASTA, cboInventario).ToList();

                        var iTOTAL_VALORIZADO = lista.Sum(x => x.Total_Valorizado_General);

                        totalDeRegistros = lista.Count();

                        lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                        if (lista.Count > 0)
                        {
                            ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                        }
                        else
                        {
                            ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU BUSQUEDA";

                            lista = null;
                        }
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "INGRESE UN RANGO DE FECHAS DE ALTA DE LOTES PARA INICIAR LA BUSQUEDA";

                lista = null;
            }

            ViewBag.items = DALSIGMA.Obtener_Combo_Inventario();

            var modelo = new Lotes_Inventario_Pagina();

            modelo.Lotes_Inventario = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["txtFECHA_DESDE"] = txtFECHA_DESDE;
            modelo.ValoresQueryString["txtFECHA_HASTA"] = txtFECHA_HASTA;
            modelo.ValoresQueryString["cboInventario"] = cboInventario;

            return View(modelo);
        }

        public ActionResult Inventario_Valorizado(int pagina = 1, string cboInventario = "", string txtAÑO = "")
        {
            ViewBag.Message = "Lotes Inventario";

            List<SIGMA_spInventario_Valorizado_Obtener_Result> lista = new List<SIGMA_spInventario_Valorizado_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 6;

            if (cboInventario.Trim() != "" && txtAÑO.Trim() != "" && txtAÑO.Trim().Length == 4)
            {
                lista = DALSIGMA.Obtener_Inventario_Valorizado(cboInventario, txtAÑO).ToList();

                var iTOTAL_VALORIZADO = lista.Sum(x => x.Valor_Actualizado);

                totalDeRegistros = lista.Count();

                lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                if (lista.Count > 0)
                {
                    ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                }
                else
                {
                    ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU BUSQUEDA";

                    lista = null;
                }
            }
            else
            {
                if (cboInventario.Trim() == "")
                {
                    ViewBag.Mensaje = "SELECCIONE UN INVENTARIO DE EFECTOS PARA INICIAR LA BUSQUEDA";

                    lista = null;
                }
                else
                {
                    if (txtAÑO.Trim() == "")
                    {
                        ViewBag.Mensaje = "INGRESE UN AÑO DE ALTA DE LOTE PARA INICIAR LA BUSQUEDA";

                        lista = null;
                    }
                    else
                    {
                        ViewBag.Error = "FORMATO DE AÑO DE ALTA INCORRECTO - VERIFIQUE";

                        lista = null;
                    }
                }
            }

            ViewBag.items = DALSIGMA.Obtener_Combo_Inventario();

            var modelo = new Inventario_Valorizado_Pagina();

            modelo.Inventario_Valorizado = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["cboInventario"] = cboInventario;
            modelo.ValoresQueryString["txtAÑO"] = txtAÑO;

            return View(modelo);
        }

        public ActionResult Altas_Totalizadas(int pagina = 1, string cboInventario = "", string txtAÑO_DESDE = "", string txtAÑO_HASTA = "")
        {
            ViewBag.Message = "Altas Totalizadas";

            List<SIGMA_spAltas_Totalizadas_Obtener_Result> lista = new List<SIGMA_spAltas_Totalizadas_Obtener_Result>();

            var totalDeRegistros = 0;

            var cantidadRegistrosPorPagina = 6;

            bool bHayError = false;

            if (txtAÑO_DESDE.Trim() != "")
            {
                if (txtAÑO_DESDE.Length != 4)
                {
                    ViewBag.Error = "LONGITUD DE AÑO DESDE INCORRECTO - VERIFIQUE";

                    lista = null;

                    bHayError = true;
                }
            }
            if (txtAÑO_HASTA.Trim() != "")
            {
                if (txtAÑO_HASTA.Length != 4)
                {
                    ViewBag.Error = "LONGITUD DE AÑO HASTA INCORRECTO - VERIFIQUE";

                    lista = null;

                    bHayError = true;
                }
            }

            if (!bHayError)
            {
                if (cboInventario.Trim() != "")
                {
                    lista = DALSIGMA.Obtener_Altas_Totalizadas(cboInventario, txtAÑO_DESDE, txtAÑO_HASTA).ToList();

                    var iTOTAL_VALORIZADO = lista.Sum(x => x.Total_Valorizado);

                    totalDeRegistros = lista.Count();

                    lista = lista.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

                    if (lista.Count > 0)
                    {
                        ViewBag.Resultado = "TOTAL VALORIZADO ===> " + iTOTAL_VALORIZADO.ToString();
                    }
                    else
                    {
                        ViewBag.Resultado = "NO SE ENCONTRARON REGISTROS PARA SU BUSQUEDA";

                        lista = null;
                    }
                }
                else
                {
                    ViewBag.Mensaje = "SELECCIONE UN INVENTARIO DE EFECTOS PARA INICIAR LA BUSQUEDA";

                    lista = null;
                }
            }

            ViewBag.items = DALSIGMA.Obtener_Combo_Inventario();

            var modelo = new Altas_Totalizadas_Pagina();

            modelo.Altas_Totalizadas = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            modelo.ValoresQueryString = new System.Web.Routing.RouteValueDictionary();
            modelo.ValoresQueryString["cboInventario"] = cboInventario;
            modelo.ValoresQueryString["txtAÑO_DESDE"] = txtAÑO_DESDE;
            modelo.ValoresQueryString["txtAÑO_HASTA"] = txtAÑO_HASTA;

            return View(modelo);
        }
    }
}