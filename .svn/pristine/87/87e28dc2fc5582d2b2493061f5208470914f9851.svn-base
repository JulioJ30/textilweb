using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TSC_WEB.Models.Entidades.Logistica.AcumuladoXCuenta;
using TSC_WEB.Models.Entidades.Logistica.AprobacionExcedentes;
using TSC_WEB.Models.Entidades.Logistica.AprobacionOC;
using TSC_WEB.Models.Modelos.Logistica.AcumGerCecoCuenta;
using TSC_WEB.Models.Modelos.Logistica.AcumuladoXCuenta;
using TSC_WEB.Models.Modelos.Logistica.AlterarSituacionOC;
using TSC_WEB.Models.Modelos.Logistica.AprobacionExcedentes;
using TSC_WEB.Models.Modelos.Logistica.AprobacionOC;
using TSC_WEB.Models.Modelos.Logistica.OCPendienteCierre;
using TSC_WEB.Models.Modelos.Logistica.OCPendienteFirma;
using TSC_WEB.Models.Modelos.Logistica.PlanContable;
using TSC_WEB.Models.Modelos.Sistema;
using TSC_WEB.Util.Sistema;

namespace TSC_WEB.Controllers
{
    public class LogisticaController : Controller
    {

        #region INSTANCIAS

        AprobacionOcModelo objAprobacionOcM = new AprobacionOcModelo();
        AlterarSituacionOcModelo objAlterarSituacionOcM = new AlterarSituacionOcModelo();
        UsuariosModelo objUsuariosM = new UsuariosModelo();

        #endregion

        #region VISTAS
        public ActionResult AprobacionOCold()
        {
            if (Session["usuario"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }
        public ActionResult AprobacionOC()
        {
            if (Session["usuario"] != null)
            {
                return View(objAprobacionOcM.ListarOcLiberarV2(Session["usuario"].ToString(),
                            Convert.ToInt32(Session["empresa"].ToString())));
            }
            else
            {
                return Redirect("/");
            }
        }
        public ActionResult AlterarSituacion()
        {
            if (Session["usuario"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }
        public ActionResult AsignacionPresupuesto()
        {
            if (Session["usuario"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }
        public ActionResult AprobacionExcedente()
        {

            if (URL_EXTERNO.URL == null) { URL_EXTERNO.URL = Request.Url.OriginalString; }
            if (Session["usuario"] != null)
            {
                AprobExcOcModelo modelo = new AprobExcOcModelo();
                var list = modelo.UsuariosPermitidos();
                string usuarioLogin = Session["usuario"].ToString();

                if (list.Exists(x => x == usuarioLogin))
                {
                    URL_EXTERNO.URL = null;
                    return View();
                }
                else
                {
                    URL_EXTERNO.URL = null;
                    return Redirect("/");
                }
            }
            else
            {
                return Redirect("/");
            }
        }
        public ActionResult RegistroConsumo()
        {
            if (Session["usuario"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }
        public ActionResult AcumuladoXCuenta()
        {
            if (Session["usuario"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }
        public ActionResult AcumGerCecoCuenta()
        {
            if (Session["usuario"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }

        //public ActionResult OcPendientesFirma()
        //{
        //    if (Session["usuario"] != null)
        //    {
        //        return View(objAprobacionOcM.ListarOcPendientesLiberar(0, string.Empty));
        //    }
        //    else
        //    {
        //        return Redirect("/");
        //    }
        //}

        public ActionResult OCPendientesFirma()
        {
            if (Session["usuario"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }

        public ActionResult OcPendienteCierre()
        {

            if (Session["usuario"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }


        #endregion

        #region METODOS


        [HttpGet]
        //CAMBIA ESTADO DETALLE DE ORDEN COMPRA
        public JsonResult ValidarLiberacion(int ordencompra, int empresa, string usuario)
        {
            AprobacionOcModelo ocModelo = new AprobacionOcModelo();
            return Json(ocModelo.CambiarEstadoDetalle(ordencompra, empresa, usuario), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarOCAlterarSituacion(int codperiodo, int codgerencia)
        {
            AlterarSituacionOcModelo objModelo = new AlterarSituacionOcModelo();
            return Json(objModelo.ListarOcAlterarSituacion(codperiodo, codgerencia), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ListarOcExcentePendientes(int codperiodo, int codgerencia)
        {
            bool isRedirect = false;
            string redirectUrl = "";
            bool estado = false;
            IEnumerable<ListaPendiente> lista = null;
            string mensaje = "";

            try
            {
                if (Session["usuario"] != null)
                {
                    AprobExcOcModelo modelo = new AprobExcOcModelo();
                    lista = modelo.ListarOcExcentePendientes(codgerencia, codperiodo, Session["usuario"].ToString()).ToList();
                    estado = true;
                    isRedirect = false;
                    redirectUrl = "";
                    mensaje = "";
                }
                else
                {
                    estado = false;
                    lista = null;
                    redirectUrl = "/login/index";
                    isRedirect = true;
                    mensaje = "";
                }
            }
            catch (Exception e)
            {
                isRedirect = true;
                mensaje = e.Message;
            }

            return Json(new
            {
                lista = lista,
                estado = estado,
                isRedirect = isRedirect,
                redirectUrl = redirectUrl,
                mensaje = mensaje
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        //VALIDA USUARIO
        public JsonResult ValidarUsuario(string usuario, string clave)
        {

            var rpt = objUsuariosM.Login(usuario, clave, false);

            if (rpt.usuario != null)
            {
                rpt = objUsuariosM.Login(usuario, clave, true);
                if (rpt.usuario != null)
                {
                    return Json(new { result = true, mensaje = "Acceso concedido" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { result = false, mensaje = "Clave incorrecta" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { result = false, mensaje = "Usuario no existe" }, JsonRequestBehavior.AllowGet);
            }
        }

        //LISTA CABECERA
        [HttpGet]
        public JsonResult ListarCabeceraOC(int ordencompra)
        {
            return Json(objAprobacionOcM.ListarCabecera(ordencompra), JsonRequestBehavior.AllowGet);
        }

        //LISTA DETALLE
        [HttpGet]
        public JsonResult ListarDetalleOC(int ordencompra)
        {
            return Json(objAprobacionOcM.ListarDetalle(ordencompra), JsonRequestBehavior.AllowGet);
        }




        //LISTA DETALLE - ALTERAR SITUACION
        [HttpGet]
        public JsonResult ListarDetalleOCAlterSit(int ordencompra)
        {
            return Json(objAlterarSituacionOcM.ListarDetalleOCAlter(ordencompra), JsonRequestBehavior.AllowGet);
        }

        //OBTIENE PERIODO ACTUAL
        [HttpGet]
        public JsonResult DetalleCabecera(int ordencompra)
        {
            return Json(objAprobacionOcM.DetalleCabecera(ordencompra), JsonRequestBehavior.AllowGet);
        }

        //OBTIENE GERENCIAS
        [HttpGet]
        public JsonResult ListarGerencias()
        {
            AlterarSituacionOcModelo modelo = new AlterarSituacionOcModelo();
            return Json(modelo.ListarCbxGerencias(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarPlanContable(int codperiodo, int codgerencia)
        {
            PlanContableModelo modelo = new PlanContableModelo();
            return Json(modelo.ListaPlanContable(codperiodo, codgerencia), JsonRequestBehavior.AllowGet);
        }



        //OBTIENE RESUMEN INDICADORES.
        [HttpGet]
        public JsonResult ListarResumen(int codgerencia, int codperiodo)
        {
            return Json(objAlterarSituacionOcM.ListarResumen(
                    codgerencia,
                    codperiodo),
                    JsonRequestBehavior.AllowGet);
        }


        // OBTIENE PERIODO DE PRESUPUESTO.
        [HttpGet]
        public JsonResult ListarPeriodos()
        {
            AlterarSituacionOcModelo objModel = new AlterarSituacionOcModelo();
            return Json(objModel.ListarCbxPeriodo(), JsonRequestBehavior.AllowGet);
        }

        //LIBERAR OC
        [HttpGet]
        public JsonResult LiberarOC(int ordencompra, int empresa, string usuario)
        {
            return Json(objAprobacionOcM.LiberarOc(ordencompra, usuario, empresa), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult LiberarOcMasivo(int[] ordenes)
        {
            int contador = 0;
            string mensaje = string.Empty;
            bool rpt = true;
            try
            {
                for (int x = 0; x < ordenes.Length; x++)
                {
                    var obj = objAprobacionOcM.LiberarOc(ordenes[x],
                                                         Session["usuario"].ToString(),
                                                         Convert.ToInt32(Session["empresa"].ToString()));
                    if (obj.respuestabool)
                    {
                        contador++;
                    }
                }
                mensaje = contador == ordenes.Length ? "Se liberaron todas las ordenes" : "Se liberaron: " + contador.ToString() + "ordenes de un total de :" + ordenes.Length.ToString();
                rpt = true;
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                rpt = false;
            }

            return Json(new { mensaje = mensaje, success = rpt });
        }

        //RECHAZAR
        [HttpPost]
        public JsonResult RechazarOcMasivo(int[] ordenes, string motivo)
        {
            int contador = 0;
            string mensaje = string.Empty;
            bool rpt = true;
            bool isRedirect = false;
            string redirectUrl = "";
            bool estado = false;

            try
            {
                if (Session["usuario"] != null)
                {
                    for (int x = 0; x < ordenes.Length; x++)
                    {
                        var obj = objAprobacionOcM.RechazarOcV2(ordenes[x],
                                                                Session["usuario"].ToString(),
                                                                motivo);

                        if (obj.respuestabool)
                        {
                            contador++;
                        }
                    }

                    mensaje = contador == ordenes.Length ? "Se Recharazon todas las ordenes" : "Se liberaron: " + contador.ToString() + "ordenes de un total de :" + ordenes.Length.ToString();
                    rpt = true;
                    estado = true;
                    isRedirect = false;
                    redirectUrl = "";
                    mensaje = "";

                }
                else
                {
                    estado = false;
                    redirectUrl = "/login/index";
                    isRedirect = true;
                    mensaje = "";
                }

            }
            catch (Exception e)
            {
                mensaje = e.Message;
                rpt = false;
            }


            return Json(new
            {
                estado = estado,
                isRedirect = isRedirect,
                redirectUrl = redirectUrl,
                mensaje = mensaje,
                success = rpt

            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult AlterarSituacionOcMasivo(int[] ordenes, int codperiodo)
        {
            int contador = 0;
            string mensaje = "";
            string mensajedet = "";
            string oc_error = "";
            bool rpt = true;
            int opcion_mensje = 0;
            int id_status = 0;
            int oc = 0;
            bool isRedirect = false;
            string redirectUrl = "";

            try
            {
                if (Session["usuario"] != null)
                {
                    for (int x = 0; x < ordenes.Length; x++)
                    {
                        AlterarSituacionOcModelo modelo = new AlterarSituacionOcModelo();
                        var validacion = modelo.AlterSituacionValidacion(ordenes[x], codperiodo);

                        if (validacion.id_status == 1)
                        {
                            var obj = modelo.AlterarSituacionOc(ordenes[x], Session["usuario"].ToString(), codperiodo);

                            if (obj.id_status == 1)
                            {
                                contador++;
                            }
                            else
                            {
                                rpt = false;
                                mensaje = obj.desc_status;
                                mensajedet = obj.desc_status;
                                oc_error = ordenes[x].ToString();
                                break;
                            }
                        }
                        else
                        {
                            oc = ordenes[x];
                            id_status = validacion.id_status;
                            mensaje = validacion.desc_status;
                            mensajedet = validacion.desc_status;
                            rpt = false;
                            opcion_mensje = 1;
                        }
                    }

                    if (opcion_mensje == 0)
                    {
                        if (contador == ordenes.Length)
                        {
                            mensaje = "Se alteró la situación de todas las OC";
                            mensajedet = "Textile Sourcing Company";
                        }
                        else
                        {
                            mensaje = "La Orden de Compra: " + oc_error + ", no se altero de situación.";
                        }
                    }
                }
                else
                {
                    isRedirect = true;
                    redirectUrl = "/login/index";
                }
            }
            catch (Exception e)
            {
                mensaje = "Controller Alterar: " + e.Message;
                mensajedet = e.StackTrace;
                rpt = false;
            }

            return Json(new
            {
                isRedirect = isRedirect,
                redirectUrl = redirectUrl,
                mensaje = mensaje,
                success = rpt,
                id_estado = id_status,
                oc = oc,
                mensajedet = mensajedet
            });
        }

        [HttpPost]
        public JsonResult RegistrarSoliExc(int ordencompra, string motivo)
        {
            string mensaje = "";
            bool rpt = true;
            bool isRedirect = false;
            string redirectUrl = "";

            try
            {
                if (Session["usuario"] != null)
                {
                    AlterarSituacionOcModelo modelo = new AlterarSituacionOcModelo();
                    var obj = modelo.RegistrarSoliExc(ordencompra,
                                                      Session["usuario"].ToString(),
                                                      motivo);

                    if (obj.id_status == 0)
                    {
                        mensaje = obj.desc_status;
                        rpt = false;
                    }
                    else
                    {
                        // Enviar Correo.
                        modelo = new AlterarSituacionOcModelo();
                        var objEmail = modelo.OC_EnviarEmail(ordencompra, Session["usuario"].ToString(), motivo);

                        if (objEmail.id_status == 0)
                        {
                            mensaje = obj.desc_status;
                            rpt = false;
                        }
                        else
                        {
                            mensaje = obj.desc_status;
                            rpt = true;
                        }
                    }
                }
                else
                {
                    isRedirect = true;
                    redirectUrl = "/login/index";
                }
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                rpt = false;
            }
            return Json(new
            {
                isRedirect = isRedirect,
                redirectUrl = redirectUrl,
                mensaje = mensaje,
                success = rpt
            });
        }

        [HttpGet]
        public JsonResult ListarPlanContDetalle(int codpedcompra, int codperiodo, int codcc)
        {
            AlterarSituacionOcModelo objModel = new AlterarSituacionOcModelo();
            return Json(objModel.ListarPlanContDetalle(codpedcompra, codperiodo, codcc),
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegistrarConsumoPlan(int codperiodo, int codcc, int codplan, decimal consumo)
        {
            string mensaje = string.Empty;
            bool rpt = true;

            PlanContableModelo modelo = new PlanContableModelo();
            try
            {
                var obj = modelo.RegistrarConsumo(codperiodo,
                                                  codcc,
                                                  codplan,
                                                  consumo,
                                                  Session["usuario"].ToString());
                if (obj.id_status == 0)
                {
                    mensaje = obj.desc_status;
                    rpt = false;
                }
                else
                {
                    mensaje = obj.desc_status;
                    rpt = true;
                }
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                rpt = false;
            }
            return Json(new { mensaje = mensaje, success = rpt });
        }

        [HttpPost]
        public JsonResult AprobacionRechazo(int periodo, int ordencompra, int estado, string observacion)
        {
            string mensaje = "";
            string mensaje_det = "";
            bool rpt = true;
            bool isRedirect = false;
            string redirectUrl = "";

            try
            {
                if (Session["usuario"] != null)
                {
                    AprobExcOcModelo modelo = new AprobExcOcModelo();

                    var obj = modelo.AprobacionRechazo(periodo,
                                                        ordencompra,
                                                        Session["usuario"].ToString(),
                                                        estado,
                                                        observacion);
                    if (obj.id_status == 0)
                    {
                        mensaje = obj.desc_status;
                        mensaje_det = "";
                        rpt = false;
                    }
                    else
                    {
                        mensaje = obj.desc_status;
                        rpt = true;

                        var objEmail = modelo.EnviarEmail(estado, ordencompra, Session["usuario"].ToString(), observacion);

                        if (objEmail.id_status == 0)
                        {
                            mensaje = obj.desc_status;
                            mensaje_det = "";
                            rpt = false;
                        }
                        else
                        {
                            mensaje_det = obj.desc_status;
                            rpt = true;
                        }
                    }
                }
                else
                {
                    isRedirect = true;
                    redirectUrl = "/login/index";
                }

            }
            catch (Exception e)
            {
                mensaje = e.Message;
                mensaje_det = "";
                rpt = false;
            }

            return Json(new
            {
                isRedirect = isRedirect,
                redirectUrl = redirectUrl,
                mensaje = mensaje,
                success = rpt,
                mensaje_det = mensaje_det
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarAprobados(int codperiodo)
        {
            AprobExcOcModelo modelo = new AprobExcOcModelo();
            return Json(modelo.ListarAprobados(codperiodo, Session["usuario"].ToString()), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarRechazados(int codperiodo)
        {
            AprobExcOcModelo modelo = new AprobExcOcModelo();
            return Json(modelo.ListarRechazados(codperiodo, Session["usuario"].ToString()), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult InformacionExcedente(int periodo, int codgerencia, int codcc, int pedido)
        {
            AprobExcOcModelo modelo = new AprobExcOcModelo();
            return Json(modelo.InformacionExcedente(periodo, codgerencia, codcc, pedido),
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarSecciones(int[] periodos, int[] secciones)
        {
            List<ListaSeccion> lista = new List<ListaSeccion>();
            List<ListaSeccion> lista_temp = null;
            AcumuladoXCuentaModelo modelo = new AcumuladoXCuentaModelo();
            List<int> ListaCodSeccion = new List<int>();

            if (secciones != null)
            {
                for (int j = 0; j < secciones.Length; j++)
                {
                    ListaCodSeccion.Add(secciones[j]);
                }
            }

            if (periodos != null)
            {
                for (int i = 0; i < periodos.Length; i++)
                {
                    lista_temp = new List<ListaSeccion>();
                    lista_temp = modelo.ListarSeccionMult(periodos[i]);

                    foreach (var item in lista_temp)
                    {
                        if (!ListaCodSeccion.Contains(item.CODSECCION))
                        {
                            lista.Add(new ListaSeccion
                            {
                                CODSECCION = item.CODSECCION,
                                SECCION = item.SECCION
                            });
                            ListaCodSeccion.Add(item.CODSECCION);
                        }
                    }
                }
            }

            ListaCodSeccion.Clear();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarFamilias(int[] periodos, int[] secciones, int[] familias, int opcion)
        {
            AcumuladoXCuentaModelo modelo = new AcumuladoXCuentaModelo();
            List<ListaFamilia> lista_temp = null;
            List<ListaFamilia> lista = new List<ListaFamilia>();
            List<int> ListaCodFamilia = new List<int>();
            string lista_secciones = "";

            if (familias != null && opcion == 1)
            {
                for (int j = 0; j < familias.Length; j++)
                {
                    ListaCodFamilia.Add(familias[j]);
                }
            }

            // Obtener lista de Secciones.
            if (secciones != null)
            {
                for (int i = 0; i < secciones.Length; i++)
                {
                    lista_secciones = lista_secciones + secciones[i].ToString() + ",";
                }
                lista_secciones = lista_secciones.TrimEnd(',');
            }


            if (periodos != null)
            {
                for (int i = 0; i < periodos.Length; i++)
                {
                    lista_temp = new List<ListaFamilia>();

                    lista_temp = modelo.ListarFamiliaMult(periodos[i], lista_secciones);

                    foreach (var item in lista_temp)
                    {
                        if (!ListaCodFamilia.Contains(item.CODFAMILIA))
                        {
                            lista.Add(new ListaFamilia
                            {
                                CODFAMILIA = item.CODFAMILIA,
                                FAMILIA = item.FAMILIA
                            });

                            ListaCodFamilia.Add(item.CODFAMILIA);
                        }
                    }
                }
            }

            ListaCodFamilia.Clear();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarCuenta(int[] periodos, int[] secciones, int[] familias, int[] cuentas, int opcion)
        {
            AcumuladoXCuentaModelo modelo = new AcumuladoXCuentaModelo();
            List<ListaCuenta> lista_temp = null;
            List<ListaCuenta> lista = new List<ListaCuenta>();
            List<int> ListaCodCuenta = new List<int>();

            string lista_secciones = "";
            string lista_familias = "";

            if (cuentas != null && opcion == 1)
            {
                for (int j = 0; j < cuentas.Length; j++)
                {
                    ListaCodCuenta.Add(cuentas[j]);
                }
            }

            // Obtener lista de Secciones.
            if (secciones != null)
            {
                for (int i = 0; i < secciones.Length; i++)
                {
                    lista_secciones = lista_secciones + secciones[i].ToString() + ",";
                }
                lista_secciones = lista_secciones.TrimEnd(',');
            }

            // Obtener lista de Familia.
            if (familias != null)
            {
                for (int i = 0; i < familias.Length; i++)
                {
                    lista_familias = lista_familias + familias[i].ToString() + ",";
                }
                lista_familias = lista_familias.TrimEnd(',');
            }

            if (periodos != null)
            {
                for (int i = 0; i < periodos.Length; i++)
                {
                    lista_temp = new List<ListaCuenta>();

                    lista_temp = modelo.ListarCuentaMult(periodos[i], lista_secciones, lista_familias);

                    foreach (var item in lista_temp)
                    {
                        if (!ListaCodCuenta.Contains(item.CODPLACONT))
                        {
                            lista.Add(new ListaCuenta
                            {
                                CODPLACONT = item.CODPLACONT,
                                PLANCONT = item.PLANCONT
                            });

                            ListaCodCuenta.Add(item.CODPLACONT);
                        }
                    }
                }
            }

            ListaCodCuenta.Clear();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarIndicadores(int[] periodos, int[] secciones, int[] familias, int[] cuentas)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            AcumuladoXCuentaModelo modelo = new AcumuladoXCuentaModelo();
            IndicadoresPresupuesto obj_temp = new IndicadoresPresupuesto();

            string lista_secciones = "";
            string lista_familias = "";
            string lista_cuentas = "";

            decimal presupuesto = 0;
            decimal consumido = 0;
            decimal disponible = 0;
            string simbolo = "";

            // Obtener lista de Secciones.
            if (secciones != null)
            {
                for (int i = 0; i < secciones.Length; i++)
                {
                    lista_secciones = lista_secciones + secciones[i].ToString() + ",";
                }
                lista_secciones = lista_secciones.TrimEnd(',');
            }

            // Obtener lista de Familia.
            if (familias != null)
            {
                for (int i = 0; i < familias.Length; i++)
                {
                    lista_familias = lista_familias + familias[i].ToString() + ",";
                }
                lista_familias = lista_familias.TrimEnd(',');
            }

            // Obtener lista de Cuentas.
            if (cuentas != null)
            {
                for (int i = 0; i < cuentas.Length; i++)
                {
                    if (cuentas[i].ToString() == "-1")
                    {
                        lista_cuentas = "-1";
                        break;
                    }
                    else
                    {
                        lista_cuentas = lista_cuentas + cuentas[i].ToString() + ",";
                    }
                }

                lista_cuentas = lista_cuentas.TrimEnd(',');
            }

            // Periodos.
            if (periodos != null)
            {
                for (int i = 0; i < periodos.Length; i++)
                {

                    obj_temp = modelo.ListarIndicadoresMult(periodos[i],
                                                            lista_secciones,
                                                            lista_familias,
                                                            lista_cuentas);

                    presupuesto = presupuesto + obj_temp.PRESUPUESTO;
                    consumido = consumido + obj_temp.CONSUMIDO;
                    disponible = disponible + obj_temp.DISPONIBLE;
                    simbolo = obj_temp.SIMBOLO;
                }
            }

            return Json(new
            {
                PRESUPUESTO = presupuesto.ToString("N", nfi),
                CONSUMIDO = consumido.ToString("N", nfi),
                DISPONIBLE = disponible.ToString("N", nfi),
                SIMBOLO = simbolo
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarAcumuladoMultiple(int[] periodos, int[] secciones, int[] familias, int[] cuentas)
        {
            AcumuladoXCuentaModelo modelo = new AcumuladoXCuentaModelo();
            List<ListaAcumulado> lista_temp = null;
            List<ListaAcumulado> lista = new List<ListaAcumulado>();
            List<int> ListaCodCuenta = new List<int>();

            //VisualizarOSModelo modeloOS = new VisualizarOSModelo();
            //var obj = modeloOS.ActualizarOS();


            // Validacion.
            string codSecciones = "";
            string codFamilias = "";
            string codCuentas = "";

            // 1. Secciones
            if (secciones != null)
            {
                for (int i = 0; i < secciones.Length; i++)
                {
                    codSecciones = codSecciones + secciones[i].ToString() + ",";
                }
                codSecciones = codSecciones.TrimEnd(',');
            }

            // 2. Familias
            if (familias != null)
            {
                for (int i = 0; i < familias.Length; i++)
                {
                    codFamilias = codFamilias + familias[i].ToString() + ",";
                }
                codFamilias = codFamilias.TrimEnd(',');
            }


            // 2. Cuentas
            if (cuentas != null)
            {
                for (int i = 0; i < cuentas.Length; i++)
                {
                    if (cuentas[i].ToString() == "-1")
                    {
                        codCuentas = "-1";
                        break;
                    }
                    else
                    {
                        codCuentas = codCuentas + cuentas[i].ToString() + ",";
                    }
                }
                codCuentas = codCuentas.TrimEnd(',');
            }

            // Construir Lista Principal
            if (periodos != null)
            {
                ListaAcumulado entidad = new ListaAcumulado();

                for (int i = 0; i < periodos.Length; i++)
                {
                    lista_temp = new List<ListaAcumulado>();

                    lista_temp = modelo.ListarAcumuladoMultiple(periodos[i],
                                                                codSecciones,
                                                                codFamilias,
                                                                codCuentas);

                    foreach (var item in lista_temp)
                    {
                        entidad = new ListaAcumulado();
                        entidad.MODULO = item.MODULO;
                        entidad.CODAUTORIZA = item.CODAUTORIZA;
                        entidad.CODIGO = item.CODIGO;
                        entidad.PROVEEDOR = item.PROVEEDOR;

                        if (item.FECHA == "" || item.FECHA == null)
                        {
                            entidad.FECHA = "";
                        }
                        else
                        {
                            entidad.FECHA = Convert.ToDateTime(item.FECHA.ToString()).ToShortDateString();
                        };
                        entidad.SIMBOLO = item.SIMBOLO;
                        entidad.SIMBOLO_S = item.SIMBOLO_S;
                        entidad.SIMBOLO_D = item.SIMBOLO_D;
                        entidad.CC = item.CC;
                        entidad.TIPO_PAGO = item.TIPO_PAGO;
                        entidad.VALOR_SOLES = item.VALOR_SOLES;
                        entidad.VALOR_DOLAR = item.VALOR_DOLAR;
                        entidad.VALOR_CONSUMIDO = item.VALOR_CONSUMIDO;

                        lista.Add(entidad);
                    }
                }
            }

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ActualizarOS()
        {
            AcumuladoXCuentaModelo modelo = new AcumuladoXCuentaModelo();
            string mensaje = "";
            if (modelo.ActualizasOS()) { mensaje = "Correcto"; } else { mensaje = "Error"; };
            return Json(new { mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarCbxGerencias(int codperiodo)
        {
            AcumGerCecoCuentaModelo modelo = new AcumGerCecoCuentaModelo();
            return Json(modelo.ListarReporteGerencia(codperiodo)
                , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarReporteCeCo(int codperiodo, int codcc, int[] codfamilias)
        {
            string familias = "";

            if (codfamilias != null)
            {
                for (int i = 0; i < codfamilias.Length; i++)
                {
                    if (codfamilias[i].ToString() == "-1")
                    {
                        familias = "-1";
                        break;
                    }
                    else
                    {
                        familias = familias + codfamilias[i].ToString() + ",";
                    }
                }
                familias = familias.TrimEnd(',');
            }

            AcumGerCecoCuentaModelo modelo = new AcumGerCecoCuentaModelo();
            return Json(modelo.ListarReporteCeCo(codperiodo, codcc, familias)
                , JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public FileResult ExportarExcelAcumuladoMult(string periodos, string secciones, string familias, string cuentas)
        {

            AcumuladoXCuentaModelo modelo = new AcumuladoXCuentaModelo();
            List<ListaAcumulado> lista_temp = null;
            List<ListaAcumulado> lista = new List<ListaAcumulado>();
            List<int> ListaCodCuenta = new List<int>();
            ListaAcumulado entidad = new ListaAcumulado();

            string[] _array_periodo_pre = periodos.Split(',');
            int[] _array_periodo = new int[_array_periodo_pre.Length];

            for (int i = 0; i < _array_periodo_pre.Length; i++)
            {
                _array_periodo[i] = Convert.ToInt32(_array_periodo_pre[i]);
            }

            for (int i = 0; i < _array_periodo.Length; i++)
            {
                lista_temp = new List<ListaAcumulado>();

                lista_temp = modelo.ListarAcumuladoMultiple(_array_periodo[i],
                                                            secciones,
                                                            familias,
                                                            cuentas);
                foreach (var item in lista_temp)
                {
                    entidad = new ListaAcumulado();

                    entidad.MODULO = item.MODULO;
                    entidad.MODULO = item.MODULO;
                    entidad.CODAUTORIZA = item.CODAUTORIZA;
                    entidad.CODIGO = item.CODIGO;
                    entidad.PROVEEDOR = item.PROVEEDOR;
                    if (item.FECHA == "" || item.FECHA == null) { entidad.FECHA = ""; } else { entidad.FECHA = Convert.ToDateTime(item.FECHA.ToString()).ToShortDateString(); };
                    entidad.SIMBOLO = item.SIMBOLO;
                    entidad.SIMBOLO_S = item.SIMBOLO_S;
                    entidad.SIMBOLO_D = item.SIMBOLO_D;
                    entidad.CC = item.CC;
                    entidad.TIPO_PAGO = item.TIPO_PAGO;
                    entidad.VALOR_SOLES = item.VALOR_SOLES;
                    entidad.VALOR_DOLAR = item.VALOR_DOLAR;
                    entidad.VALOR_CONSUMIDO = item.VALOR_CONSUMIDO;
                    entidad.V_SOLES = item.V_SOLES;
                    entidad.V_DOLAR = item.V_DOLAR;
                    entidad.V_CONSUMIDO = item.V_CONSUMIDO;

                    lista.Add(entidad);
                }
            }
            return File(modelo.ExpExcelAcumuladoMult(lista), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AcumuladoXCuenta" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");
        }

        [HttpGet]
        public JsonResult PeriodosGerCeCoCuenta()
        {
            AcumGerCecoCuentaModelo objModel = new AcumGerCecoCuentaModelo();
            return Json(objModel.ListarCbxPeriodo(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GerenciasGerCeCoCuenta()
        {
            AcumGerCecoCuentaModelo objModel = new AcumGerCecoCuentaModelo();
            return Json(objModel.ListarCbxGerencias(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CeCoGerCeCoCuenta(string codperiodo, string codgerencia)
        {
            AcumGerCecoCuentaModelo objModel = new AcumGerCecoCuentaModelo();
            return Json(objModel.ListarCbxCentroCosto(Convert.ToInt32(codperiodo), Convert.ToInt32(codgerencia)),
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult FamiliaGerCeCoCuenta(string codperiodo, string codcc)
        {
            AcumGerCecoCuentaModelo objModel = new AcumGerCecoCuentaModelo();
            return Json(objModel.ListarCbxFamilias(Convert.ToInt32(codperiodo),
                                                   Convert.ToInt32(codcc)),
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarAcumuladoXCC(int codperiodo, int codgerencia)
        {
            AcumGerCecoCuentaModelo objModel = new AcumGerCecoCuentaModelo();
            return Json(objModel.ListarAcumuladoXCC(codperiodo, codgerencia), JsonRequestBehavior.AllowGet);
        }


        // Reporte de Firmas pendientes de ordenes de compra.
        [HttpGet]
        public async Task<JsonResult> ListarPendienteFirma(string firmas, DateTime fechaIni, DateTime fechaFin)
        {
            if (Session["usuario"] != null)
            {
                OCPendFirmaModel objModel = new OCPendFirmaModel();
                var lista = await objModel.ListarPendienteFirma(firmas,
                                                                Session["usuario"].ToString(),
                                                                Session["empresa"].ToString(),
                                                                fechaIni,
                                                                fechaFin);

                return Json(new
                {
                    lista = lista,
                    isRedirect = false,
                    redirectUrl = ""
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { lista = new List<object>(), isRedirect = true, redirectUrl = "/login/index" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<JsonResult> ListarPendOCDetalle(int oc)
        {
            OCPendFirmaModel objModel = new OCPendFirmaModel();
            return Json(await objModel.ListarDetalleOC(oc), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> ListarPendCboFirmas()
        {
            OCPendFirmaModel objModel = new OCPendFirmaModel();
            return Json(await objModel.ListarCboFirmas(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public FileResult ReporteExcelPendientes(string firmas, DateTime fechaIni, DateTime fechaFin)
        {
            OCPendFirmaModel objModel = new OCPendFirmaModel();
            var lista = objModel.ListaReporteExcel(firmas,
                                                    Session["usuario"].ToString(),
                                                    Session["empresa"].ToString(),
                                                    fechaIni,
                                                    fechaFin);

            return File(objModel.ReporteExcel(lista), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PendienteFirmas" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");
        }



        // Reporte de OC Pendiente de Cierre.
        [HttpGet]
        public async Task<JsonResult> ListarPendienteCierre(string niveles,
                                                            DateTime fechaIni,
                                                            DateTime fechaFin)
        {

            OCPendCierreModel objModel = new OCPendCierreModel();

            return Json(await objModel.ListarPendCierre(niveles, fechaIni, fechaFin), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public FileResult ReporteExcelPendCierre(string niveles,
                                                DateTime fechaIni,
                                                DateTime fechaFin)
        {
            OCPendCierreModel objModel = new OCPendCierreModel();
            var lista = objModel.ListaReporteExcel(niveles, fechaIni, fechaFin);
            return File(objModel.ReporteExcel(lista), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PendienteCierre" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");
        }

        [HttpGet]
        public JsonResult ListarNivelItems()
        {
            OCPendCierreModel objModel = new OCPendCierreModel();
            return Json(objModel.ListarNivelItems(), JsonRequestBehavior.AllowGet);
        }



        // Aprobacion OC - Lista de Aprobados.
        [HttpGet]
        public async Task<JsonResult> ListarAprobTercFirma(DateTime fechaIni, DateTime fechaFin)
        {
            bool isRedirect = false;
            string redirectUrl = "";
            IEnumerable<Lista2_AprobTercFirma> lista = null;

            try
            {
                if (Session["usuario"] != null)
                {
                    AprobacionOcModelo modelo = new AprobacionOcModelo();
                    lista = await modelo.ListaAprobadas(Session["usuario"].ToString(),
                                                        Convert.ToInt32(Session["empresa"].ToString()),
                                                        fechaIni,
                                                        fechaFin);
                    isRedirect = false;
                    redirectUrl = "";
                }
                else
                {
                    redirectUrl = "/login/index";
                    isRedirect = true;
                }
            }
            catch (Exception e)
            {
                isRedirect = true;
            }

            return Json(new
            {
                lista = lista,
                isRedirect = isRedirect,
                redirectUrl = redirectUrl,
            }, JsonRequestBehavior.AllowGet);
        }



        // Aprobacion OC - Lista de Aprobados.  -----------------------------------------------------------------------------------
        [HttpGet]
        public FileResult ReportExcel3eraF_Aprob(DateTime fechaIni, DateTime fechaFin)
        {
            AprobacionOcModelo modelo = new AprobacionOcModelo();

            var lista = modelo.ListaExcelAprobados(Session["usuario"].ToString(),
                                                        Convert.ToInt32(Session["empresa"].ToString()),
                                                        fechaIni,
                                                        fechaFin);

            return File(modelo.ReporteExcelAprob(lista),
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "OC_Aprobados_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");

        }

        // Aprobacion OC - Lista de Aprobados.  -----------------------------------------------------------------------------------
        [HttpGet]
        public FileResult ReportExcel3eraF_Rech(DateTime fechaIni, DateTime fechaFin)
        {
            AprobacionOcModelo modelo = new AprobacionOcModelo();

            var lista = modelo.ListaExcelRechazados(Session["usuario"].ToString(),
                                                    Convert.ToInt32(Session["empresa"].ToString()),
                                                    fechaIni,
                                                    fechaFin);

            return File(modelo.ReporteExcelRech(lista),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "OC_Rechazados_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");

        }


        // Aprobacion OC - Lista de Rechazados
        [HttpGet]
        public async Task<JsonResult> ListarRechTercFirma(DateTime fechaIni, DateTime fechaFin)
        {
            bool isRedirect = false;
            string redirectUrl = "";
            IEnumerable<Lista3_RechTercFirma> lista = null;

            try
            {
                if (Session["usuario"] != null)
                {
                    AprobacionOcModelo modelo = new AprobacionOcModelo();
                    lista = await modelo.ListaRechazados(Session["usuario"].ToString(),
                                                        Convert.ToInt32(Session["empresa"].ToString()),
                                                        fechaIni,
                                                        fechaFin);
                    isRedirect = false;
                    redirectUrl = "";
                }
                else
                {
                    redirectUrl = "/login/index";
                    isRedirect = true;
                }
            }
            catch (Exception e)
            {
                isRedirect = true;
            }

            return Json(new
            {
                lista = lista,
                isRedirect = isRedirect,
                redirectUrl = redirectUrl,
            }, JsonRequestBehavior.AllowGet);
        }

    }

    // Aprobacion OC - Lista de Rechazados.




    #endregion

}