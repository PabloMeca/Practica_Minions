using System;
using System.Collections.Generic;
using CapaDAL = BCR.PracticaMinions4.DAL;
using CapaETL = BCR.PracticaMinions4.ETL;
using clsConstantes = BCR.PracticaMinions4.LIL.Constantes;

namespace BCR.PracticaMinions4.BLL
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
    public class Evaluaciones
    {
        CapaDAL.AccesoGenerico bllAccesoGenerico = new CapaDAL.AccesoGenerico();
        CapaETL.Respuesta respuesta = new CapaETL.Respuesta();

        /// <summary>
        ///     Ejecuta el método de consumo de procedimientos almacenados y retorna un objeto de respuesta con 
        ///     una lista de evaluaciones.
        /// </summary>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta MostrarEvaluaciones()
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.MOSTRAREVALUACIONES, parametros);
            }
            catch (Exception e)
            {
                respuesta.codigoRespuesta = clsConstantes.CodigosRespuestas.CODIGOICORRECTO;
                respuesta.mensajeRespuesta = e.Message;
                return respuesta;
            }
        }

        /// <summary>
        ///      Ejecuta el método de consumo de procedimientos almacenados e inserta una reserva.
        /// </summary>
        /// <param name="objEvaluacion"></param>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta InsertarEvaluaciones(CapaETL.Evaluacion objEvaluacion)
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                parametros.Add(clsConstantes.Procedimientos.Parametros.NOMBREEVALUACION, objEvaluacion.nombre);
                parametros.Add(clsConstantes.Procedimientos.Parametros.DESCRIPCIONEVALUACION, objEvaluacion.descripcion);
                parametros.Add(clsConstantes.Procedimientos.Parametros.CANTIDADCALIFICACIONES, objEvaluacion.cantidadCalificaciones);
                return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.INSERTAREVALUACIONES, parametros);
            }
            catch (Exception e)
            {
                respuesta.codigoRespuesta = clsConstantes.CodigosRespuestas.CODIGOICORRECTO;
                respuesta.mensajeRespuesta = e.Message;
                return respuesta;
            }
        }
    }
}
