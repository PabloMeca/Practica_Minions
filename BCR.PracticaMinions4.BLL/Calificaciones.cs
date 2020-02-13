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
    public class Calificaciones
    {
        CapaDAL.AccesoGenerico bllAccesoGenerico = new CapaDAL.AccesoGenerico();
        CapaETL.Respuesta respuesta = new CapaETL.Respuesta();

        /// <summary>
        ///     Ejecuta el método de consumo de procedimientos almacenados y retorna un objeto de respuesta con 
        ///     una lista de calificaciones.
        /// </summary>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta MostrarCalificaciones()
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.MOSTRARCALIFICACIONES, parametros);
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
        /// <param name="objCalificacion"></param>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta InsertarCalificaciones(CapaETL.Calificacion objCalificacion)
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                parametros.Add(clsConstantes.Procedimientos.Parametros.CEDULACALIFICANTE, objCalificacion.cedulaCalificante);
                parametros.Add(clsConstantes.Procedimientos.Parametros.CODIGOEVALUACION, objCalificacion.codigoEvaluacion);
                parametros.Add(clsConstantes.Procedimientos.Parametros.CALIFICACION, objCalificacion.calificacion);
                return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.INSERTARCALIFICACIONES, parametros);
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
