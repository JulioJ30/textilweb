using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TSC_WEB.Models.Modelos.Facturacion.ReporteVentas;

namespace TSC_WEB.Controllers
{
    public class FacturacionController : Controller
    {


        public ActionResult ReporteVentas()
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


        [HttpGet]
        public async Task<JsonResult> ListarVentas(string series, DateTime fechaIni, DateTime fechaFin)
        {
            if (Session["usuario"] != null)
            {
                ReporteVentasModelo objModel = new ReporteVentasModelo();

                var lista = await objModel.ListarVentas(series, fechaIni, fechaFin);

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
        public async Task<JsonResult> ListarSeries()
        {
            if (Session["usuario"] != null)
            {
                ReporteVentasModelo objModel = new ReporteVentasModelo();
                var lista = await objModel.ListarSeries();

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
        public FileResult RepExcelVentas(string series, DateTime fechaIni, DateTime fechaFin)
        {
            ReporteVentasModelo objModel = new ReporteVentasModelo();
            var lista = objModel.ListaReporte(series, fechaIni, fechaFin);
            return File(objModel.ReporteExcel(lista), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteVentas_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");
        }



    }
}