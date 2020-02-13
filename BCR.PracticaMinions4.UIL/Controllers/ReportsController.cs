using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Web.Mvc;
using clsConstantes = BCR.PracticaMinions4.LIL.Constantes;

namespace BCR.PracticaMinions4.UIL.Controllers
{
    /// <summary>
    ///     <createddate>2020-02-10</createddate>
    ///     <company>Grupo Babel</company>
    ///     <lastmodificationdate>2020-02-10</lastmodificationdate>
    ///     <lastmodificationdescription>
    ///         Se agregaron los comentarios a la clase.
    ///     </lastmodificationdescription>
    ///     <lastmodifierautor>Jeison Jiménez</lastmodifierautor>
    /// </summary>
    public class ReportsController : Controller
    {
        BLL.Reservas bllReservas = new BLL.Reservas();  

        /// <summary>
        ///     Metodo que lleva a una pagina con un reporte de reservas
        /// </summary>
        /// <returns>Vista de reporte de reservas</returns>
        public ActionResult Reservas(int idVuelo)
        {
            ReportViewer viewer = new ReportViewer();
            try
            {
                //Datasource
                var resultadoConsulta = bllReservas.MostrarReservas();
              
                //Seteo del reporte
                viewer.ShowExportControls = true;
                viewer.ShowPrintButton = true;
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.SizeToReportContent = true;
                viewer.AsyncRendering = true;
                viewer.LocalReport.ReportPath = clsConstantes.Reportes.RESERVAS;

                DataTable dt = new DataTable();
                dt.Columns.Add(clsConstantes.Columnas.CODIGORESERVA);
                dt.Columns.Add(clsConstantes.Columnas.CODIGOVUELO);
                dt.Columns.Add(clsConstantes.Columnas.DESTINOS);
                dt.Columns.Add(clsConstantes.Columnas.FECHASALIDA);
                dt.Columns.Add(clsConstantes.Columnas.NOMBRECLIENTE);
                dt.Columns.Add(clsConstantes.Columnas.CANTIDADNOFUMADORES);
                dt.Columns.Add(clsConstantes.Columnas.CANTIDADFUMADORES);

                foreach (var objReserva in resultadoConsulta.objetoRespuesta)
                {
                    DataRow row = dt.NewRow();
                    row[clsConstantes.Columnas.CODIGORESERVA] = objReserva.codigoReserva;
                    row[clsConstantes.Columnas.CODIGOVUELO] = objReserva.codigoVuelo;
                    row[clsConstantes.Columnas.DESTINOS] = objReserva.destinos;
                    row[clsConstantes.Columnas.FECHASALIDA] = objReserva.fechaSalida;
                    row[clsConstantes.Columnas.NOMBRECLIENTE] = objReserva.nombreCliente;
                    row[clsConstantes.Columnas.CANTIDADNOFUMADORES] = objReserva.cantidadNoFumadores;
                    row[clsConstantes.Columnas.CANTIDADFUMADORES] = objReserva.cantidadFumadores;
                    dt.Rows.Add(row);
                }

                DataSet ds = new DataSet(clsConstantes.Datasets.RESERVAS);
                ds.Tables.Add(dt);
                ReportParameter p1 = new ReportParameter("idVuelo", idVuelo.ToString());
                viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });
                viewer.LocalReport.DataSources.Add(new ReportDataSource(clsConstantes.Datasets.MYDATASET, ds.Tables[0]));
                ViewBag.ReportViewer = viewer;
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Reservas");
                return Content(CodigoJavaScript);
            }
            return View();
        }
    }
}