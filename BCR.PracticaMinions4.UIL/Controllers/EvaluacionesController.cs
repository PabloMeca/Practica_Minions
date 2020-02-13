using System;
using System.Web.Mvc;
using CapaBLL = BCR.PracticaMinions4.BLL;
using CapaETL = BCR.PracticaMinions4.ETL;
using clsConstantes = BCR.PracticaMinions4.LIL.Constantes;
using Mensajes = BCR.PracticaMinions4.LIL.Recursos.Mensajes;

namespace BCR.PracticaMinions4.UIL.Controllers
{
    /// <summary>
    ///     <createddate>2020-02-05</createddate>
    ///     <company>Grupo Babel</company>
    ///     <lastmodificationdate>2020-02-05</lastmodificationdate>
    ///     <lastmodificationdescription>
    ///         Se agregaron los comentarios a la clase.
    ///     </lastmodificationdescription>
    ///     <lastmodifierautor>Jeison Jiménez</lastmodifierautor>
    /// </summary>
    public class EvaluacionesController : Controller
    {
        #region Inicializacion de variables
        CapaETL.Respuesta respuesta = new CapaETL.Respuesta();
        CapaBLL.Evaluaciones bllEvaluaciones = new CapaBLL.Evaluaciones();
        CapaBLL.Calificaciones bllCalificaciones = new CapaBLL.Calificaciones();
        #endregion

        #region Evaluaciones
        /// <summary>
        ///     Metodo que retorna la vista inicial
        /// </summary>
        /// <returns>Vista index</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     Metodo que retorna la vista de evaluaciones con un modelo de evaluaciones
        /// </summary>
        /// <returns>Vista evaluaciones</returns>
        public ActionResult Evaluaciones()
        {
            try
            {
                return View(bllEvaluaciones.MostrarEvaluaciones().objetoRespuesta);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Evaluaciones/Evaluaciones");
                return Content(CodigoJavaScript);
            }
        }

        /// <summary>
        ///     Metodo que retorna la vista donde se agregan evaluaciones
        /// </summary>
        /// <returns>Vista agregar evaluaciones</returns>
        public ActionResult AgregarEvaluaciones()
        {
            return View();
        }

        /// <summary>
        ///     Metodo que inserta las evaluaciones
        /// </summary>
        /// <param name="txtNombre"></param>
        /// <param name="txtDescripcion"></param>
        /// <param name="txtCantidad"></param>
        /// <returns>Codigo js que tiene un mensaje de respuesta</returns>
        public ActionResult InsertarEvaluaciones(string txtNombre, string txtDescripcion, string txtCantidad)
        {
            try
            {
                string CodigoJavaScript;
                if (string.IsNullOrEmpty(txtNombre) || string.IsNullOrEmpty(txtDescripcion) || string.IsNullOrEmpty(txtCantidad))
                {
                    //Se le da formato a la funcion javascript de retorno
                    CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjErrorCamposVacios, "/Evaluaciones/AgregarEvaluaciones");
                }
                else
                {
                    CapaETL.Evaluacion evaluacion = new CapaETL.Evaluacion();
                    evaluacion.nombre = txtNombre;
                    evaluacion.descripcion = txtDescripcion;
                    evaluacion.cantidadCalificaciones = Convert.ToInt32(txtCantidad);

                    respuesta = bllEvaluaciones.InsertarEvaluaciones(evaluacion);
                    if (respuesta.codigoRespuesta == clsConstantes.CodigosRespuestas.CODIGOCORRECTO)
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjEvaluacionAgregada, "/Evaluaciones/Evaluaciones");
                    }
                    else
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, respuesta.mensajeRespuesta, "/Evaluaciones/Evaluaciones");
                    }
                }
                return Content(CodigoJavaScript);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Evaluaciones/Evaluaciones");
                return Content(CodigoJavaScript);
            }
        }
        #endregion

        #region
        /// <summary>
        ///     Metodo que muestra una vista de calificaciones con un modelo de calificaciones
        /// </summary>
        /// <returns>Vista calificaciones</returns>
        public ActionResult Calificaciones()
        {
            try
            {
                return View(bllCalificaciones.MostrarCalificaciones().objetoRespuesta);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Evaluaciones/Calificaciones");
                return Content(CodigoJavaScript);
            }
        }

        /// <summary>
        ///     Metodo que retorna una vista donde se agregan las calificaciones
        /// </summary>
        /// <returns>Vista agregar calificaciones</returns>
        public ActionResult AgregarCalificaciones()
        {
            try
            {
                return View(bllEvaluaciones.MostrarEvaluaciones().objetoRespuesta);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Evaluaciones/Calificaciones");
                return Content(CodigoJavaScript);
            }
        }

        /// <summary>
        ///     Metodo que inserta las calificaciones
        /// </summary>
        /// <param name="optEvaluaciones"></param>
        /// <param name="txtCedula"></param>
        /// <param name="optCalificacion"></param>
        /// <returns>Codigo js que tiene un mensaje de respuesta</returns>
        public ActionResult InsertarCalificaciones(string optEvaluaciones, string txtCedula, string optCalificacion)
        {
            try
            {
                string CodigoJavaScript;
                if (string.IsNullOrEmpty(txtCedula))
                {
                    //Se le da formato a la funcion javascript de retorno
                    CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjErrorCamposVacios, "/Evaluaciones/AgregarCalificaciones");
                }
                else if (optEvaluaciones == "0")
                {
                    CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjEvaluacionNoSeleccionada, "/Evaluaciones/AgregarCalificaciones");
                }
                else if (optCalificacion == "0")
                {
                    CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjCalificacionNoSeleccionada, "/Evaluaciones/AgregarCalificaciones");
                }
                else
                {
                    CapaETL.Calificacion calificacion = new CapaETL.Calificacion();
                    calificacion.codigoEvaluacion = Convert.ToInt32(optEvaluaciones);
                    calificacion.cedulaCalificante = txtCedula;
                    calificacion.calificacion = Convert.ToInt32(optCalificacion);

                    respuesta = bllCalificaciones.InsertarCalificaciones(calificacion);
                    if (respuesta.codigoRespuesta == clsConstantes.CodigosRespuestas.CODIGOCORRECTO)
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjCalificacionAgregada, "/Evaluaciones/Calificaciones");
                    }
                    else
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, respuesta.mensajeRespuesta, "/Evaluaciones/Calificaciones");
                    }
                }
                return Content(CodigoJavaScript);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Evaluaciones/Calificaciones");
                return Content(CodigoJavaScript);
            }
        }
        #endregion
    }
}