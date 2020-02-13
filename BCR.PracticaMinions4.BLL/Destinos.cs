using System;
using System.Collections.Generic;
using CapaDAL = BCR.PracticaMinions4.DAL;
using CapaETL = BCR.PracticaMinions4.ETL;
using clsConstantes = BCR.PracticaMinions4.LIL.Constantes;

namespace BCR.PracticaMinions4.BLL
{
    /// <summary>
    ///     <createddate>2020-01-31</createddate>
    ///     <company>Grupo Babel</company>
    ///     <lastmodificationdate>2020-01-31</lastmodificationdate>
    ///     <lastmodificationdescription>
    ///         Se agregaron los comentarios a la clase.
    ///     </lastmodificationdescription>
    ///     <lastmodifierautor>Jeison Jiménez</lastmodifierautor>
    /// </summary>
    public class Destinos
    {
        CapaDAL.AccesoGenerico bllAccesoGenerico = new CapaDAL.AccesoGenerico();
        CapaETL.Respuesta respuesta = new CapaETL.Respuesta();

        /// <summary>
        ///      Ejecuta el método de consumo de procedimientos almacenados e inserta un destino.
        /// </summary>
        /// <param name="objDestino"></param>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta InsertarDestinos(CapaETL.Destino objDestino)
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                parametros.Add(clsConstantes.Procedimientos.Parametros.DESTINOLLEGADA, objDestino.destinoLlegada);
                parametros.Add(clsConstantes.Procedimientos.Parametros.DESTINOSALIDA, objDestino.destinoSalida);
                return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.INSERTARDESTINOS, parametros);
            }
            catch (Exception e)
            {
                respuesta.codigoRespuesta = clsConstantes.CodigosRespuestas.CODIGOICORRECTO;
                respuesta.mensajeRespuesta = e.Message;
                return respuesta;
            }
        }

        /// <summary>
        ///     Ejecuta el método de consumo de procedimientos almacenados y retorna un objeto de respuesta con 
        ///     una lista de destinos.
        /// </summary>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta MostrarDestinos()
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.MOSTRARDESTINOS, parametros);
            }
            catch (Exception e)
            {
                respuesta.codigoRespuesta = clsConstantes.CodigosRespuestas.CODIGOICORRECTO;
                respuesta.mensajeRespuesta = e.Message;
                return respuesta;
            }
        }

        /// <summary>
        ///      Ejecuta el método de consumo de procedimientos almacenados y modifica un destino
        /// </summary>
        /// <param name="objDestino"></param>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta ModificarDestino(CapaETL.Destino objDestino)
        {
            try
            {
                Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
                parametros.Add(clsConstantes.Procedimientos.Parametros.CODIGODESTINO, objDestino.codigoDestino);
                parametros.Add(clsConstantes.Procedimientos.Parametros.DESTINOLLEGADA, objDestino.destinoLlegada);
                parametros.Add(clsConstantes.Procedimientos.Parametros.DESTINOSALIDA, objDestino.destinoSalida);
                return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.MODIFICARDESTINOS, parametros);
            }
            catch (Exception e)
            {
                respuesta.codigoRespuesta = clsConstantes.CodigosRespuestas.CODIGOICORRECTO;
                respuesta.mensajeRespuesta = e.Message;
                return respuesta;
            }
        }

        /// <summary>
        ///    Ejecuta el método de consumo de procedimientos almacenados y devuelve un destino que coincide con el destino enviado 
        /// </summary>
        /// <param name="objDestino"></param>
        /// <returns></returns>
        public CapaETL.Respuesta SeleccionarDestino(CapaETL.Destino objDestino)
        {
            Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
            parametros.Add(clsConstantes.Procedimientos.Parametros.CODIGODESTINO, objDestino.codigoDestino);
            return bllAccesoGenerico.ExecuteSP_WithResult(clsConstantes.Procedimientos.SELECCIONARDESTINO, parametros);
        }
    }
}
