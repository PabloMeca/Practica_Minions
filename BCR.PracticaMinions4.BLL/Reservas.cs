using System;
using System.Collections.Generic;
using CapaDAL = BCR.PracticaMinions4.DAL;
using CapaETL = BCR.PracticaMinions4.ETL;
using clsConstantes = BCR.PracticaMinions4.LIL.Constantes;

namespace BCR.PracticaMinions4.BLL
{
    /// <summary>
    ///     <createddate>2020-02-03</createddate>
    ///     <company>Grupo Babel</company>
    ///     <lastmodificationdate>2020-02-03</lastmodificationdate>
    ///     <lastmodificationdescription>
    ///         Se agregaron los comentarios a la clase.
    ///     </lastmodificationdescription>
    ///     <lastmodifierautor>Jeison Jiménez</lastmodifierautor>
    /// </summary>
    public class Reservas
    {
        CapaDAL.AccesoGenerico bllAccesoGenerico = new CapaDAL.AccesoGenerico();
        CapaETL.Respuesta respuesta = new CapaETL.Respuesta();

        /// <summary>
        ///     Ejecuta el método de consumo de procedimientos almacenados y retorna un objeto de respuesta con 
        ///     una lista de reservas.
        /// </summary>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta MostrarReservas()
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                respuesta = bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.MOSTRARRESERVAS, parametros);
                return respuesta;
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
        /// <param name="objReserva"></param>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta InsertarReservas(CapaETL.Reserva objReserva)
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                parametros.Add(clsConstantes.Procedimientos.Parametros.CODIGOVUELO, objReserva.codigoVuelo);
                parametros.Add(clsConstantes.Procedimientos.Parametros.NOMBRECLIENTE, objReserva.nombreCliente);
                parametros.Add(clsConstantes.Procedimientos.Parametros.CANTIDADNOFUMADORES, objReserva.cantidadNoFumadores);
                parametros.Add(clsConstantes.Procedimientos.Parametros.CANTIDADFUMADORES, objReserva.cantidadFumadores);
                return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.INSERTARRESERVAS, parametros);
            }
            catch (Exception e)
            {
                respuesta.codigoRespuesta = clsConstantes.CodigosRespuestas.CODIGOICORRECTO;
                respuesta.mensajeRespuesta = e.Message;
                return respuesta;
            }
        }

        /// <summary>
        ///      Ejecuta el método de consumo de procedimientos muestra los campos disponibles.
        /// </summary>
        /// <param name="objReserva"></param>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta Disponibles(CapaETL.Reserva objReserva)
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                parametros.Add(clsConstantes.Procedimientos.Parametros.CODIGOVUELO, objReserva.codigoVuelo);
                return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.MOSTRARDISPONIBLES, parametros);
            }
            catch (Exception e)
            {
                respuesta.codigoRespuesta = clsConstantes.CodigosRespuestas.CODIGOICORRECTO;
                respuesta.mensajeRespuesta = e.Message;
                return respuesta;
            }
        }

        /// <summary>
        ///      Ejecuta el método de consumo de procedimientos y elimina una reserva.
        /// </summary>
        /// <param name="objReserva"></param>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta EliminarReservas(CapaETL.Reserva objReserva)
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                parametros.Add(clsConstantes.Procedimientos.Parametros.CODIGORESERVA, objReserva.codigoReserva);
                return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.ELIMINARRESERVAS, parametros);
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
