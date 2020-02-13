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
    public class Vuelos
    {
        CapaDAL.AccesoGenerico bllAccesoGenerico = new CapaDAL.AccesoGenerico();
        CapaETL.Respuesta respuesta = new CapaETL.Respuesta();

        /// <summary>
        ///     Ejecuta el método de consumo de procedimientos almacenados y retorna un objeto de respuesta con 
        ///     una lista de destinos.
        /// </summary>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta MostrarVuelos()
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                respuesta = bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.MOSTRARVUELOS, parametros);
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
        ///      Ejecuta el método de consumo de procedimientos almacenados e inserta un vuelo.
        /// </summary>
        /// <param name="objVuelo"></param>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta InsertarVuelos(CapaETL.Vuelo objVuelo)
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                parametros.Add(clsConstantes.Procedimientos.Parametros.CODIGODESTINO, objVuelo.codigoDestino);
                parametros.Add(clsConstantes.Procedimientos.Parametros.FECHASALIDA, objVuelo.fechaSalida);
                parametros.Add(clsConstantes.Procedimientos.Parametros.CAPACIDAD, objVuelo.capacidad);
                return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.INSERTARVUELOS, parametros);
            }
            catch (Exception e)
            {
                respuesta.codigoRespuesta = clsConstantes.CodigosRespuestas.CODIGOICORRECTO;
                respuesta.mensajeRespuesta = e.Message;
                return respuesta;
            }
        }

        /// <summary>
        ///    Ejecuta el método de consumo de procedimientos almacenados y devuelve un vuelo que coincide con el vuelo enviado 
        /// </summary>
        /// <param name="objVuelo"></param>
        /// <returns></returns>
        public CapaETL.Respuesta SeleccionarVuelo(CapaETL.Vuelo objVuelo)
        {
            Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
            parametros.Add(clsConstantes.Procedimientos.Parametros.CODIGOVUELO, objVuelo.codigoVuelo);
            return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.SELECCIONARVUELO, parametros);
        }

        /// <summary>
        ///      Ejecuta el método de consumo de procedimientos almacenados y modifica un vuelo
        /// </summary>
        /// <param name="objVuelo"></param>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta ModificarVuelo(CapaETL.Vuelo objVuelo)
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                parametros.Add(clsConstantes.Procedimientos.Parametros.CODIGOVUELO, objVuelo.codigoVuelo);
                parametros.Add(clsConstantes.Procedimientos.Parametros.CAPACIDAD, objVuelo.capacidad);
                parametros.Add(clsConstantes.Procedimientos.Parametros.CODIGODESTINO, objVuelo.codigoDestino);
                parametros.Add(clsConstantes.Procedimientos.Parametros.FECHASALIDA, objVuelo.fechaSalida);
                return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.MODIFICARVUELO, parametros);
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
