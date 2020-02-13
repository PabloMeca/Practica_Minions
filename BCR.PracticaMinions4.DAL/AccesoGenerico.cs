using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaETL = BCR.PracticaMinions4.ETL;
using clsConstantes = BCR.PracticaMinions4.LIL.Constantes;

namespace BCR.PracticaMinions4.DAL
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
    public class AccesoGenerico
    {
        CapaETL.Respuesta respuesta;
        Conexion SqlConexion;

        /// <summary>
        ///     Proceso que consume los procedimientos almacenados y retorna un objeto de respuesta con una lista de entidades
        /// </summary>
        /// <param name="StoreProcedure"></param>
        /// <param name="Parametros"></param>
        /// <returns>Objeto de respuesta</returns>
        public CapaETL.Respuesta ExecuteSP_WithResult(string StoreProcedure, Dictionary<string, dynamic> Parametros)
        {
            respuesta = new CapaETL.Respuesta();
            SqlConexion = new Conexion();
            try
            {
                // Sección en la que se usa la conección
                using (SqlConexion.conexion)
                {
                    #region Recorrido y asignacion de parametros en la conexion
                    SqlCommand comando = new SqlCommand(StoreProcedure, SqlConexion.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    foreach (var item in Parametros)
                    {
                        comando.Parameters.AddWithValue(item.Key, item.Value);
                    }
                    //Se asignan los parámetros de salida esperados
                    comando.Parameters.Add(new SqlParameter(clsConstantes.Procedimientos.Parametros.CODIGORESPUESTA, SqlDbType.Int)).Direction = ParameterDirection.Output;
                    comando.Parameters.Add(new SqlParameter(clsConstantes.Procedimientos.Parametros.MENSAJERESPUESTA, SqlDbType.VarChar, 350)).Direction = ParameterDirection.Output;
                    comando.Parameters.Add(new SqlParameter(clsConstantes.Procedimientos.Parametros.ENTIDAD, SqlDbType.VarChar, 20)).Direction = ParameterDirection.Output;
                    #endregion

                    //Se abre la conexión
                    SqlConexion.OpenConexion();
                    SqlDataReader resultado = comando.ExecuteReader();
                    CapaETL.Respuesta respuestaProvisional = new CapaETL.Respuesta();
                    
                    #region Recorrida de la respuesta del procedimiento
                    var listaResultados = new List<dynamic>();

                    if (resultado.HasRows)
                    {
                        //Se recorre cada campo para fila para obtener los resultados
                        while (resultado.Read())
                        {
                            var resultadoFila = new List<dynamic>();
                            for (int i = 0; i < resultado.FieldCount; i++)
                            {
                                var valorResultado = resultado.GetValue(i);
                                resultadoFila.Add(valorResultado);
                            }
                            listaResultados.Add(resultadoFila);
                        }
                    }
                    resultado.Close();
                    respuestaProvisional.objetoRespuesta = listaResultados;
                    #endregion
                    //Se asignan las variables de respuesta
                    respuesta.codigoRespuesta = Convert.ToInt32(comando.Parameters[clsConstantes.Procedimientos.Parametros.CODIGORESPUESTA].Value);
                    respuesta.mensajeRespuesta = Convert.ToString(comando.Parameters[clsConstantes.Procedimientos.Parametros.MENSAJERESPUESTA].Value);

                    #region Direccionamiento al metodo correspondiente a la entidad
                    if (respuesta.codigoRespuesta == clsConstantes.CodigosRespuestas.CODIGOCORRECTO)
                    {
                        // Se asigna la cadena para saber a que entidad pertenece
                        string entidad = Convert.ToString(comando.Parameters[clsConstantes.Procedimientos.Parametros.ENTIDAD].Value);

                        // Le asigna los resultados a la entidad perteneciente
                        switch (entidad)
                        {
                            case clsConstantes.Entidades.DESTINO:
                                respuesta.objetoRespuesta = ProcesarDestinos(respuestaProvisional);
                                break;
                            case clsConstantes.Entidades.VUELO:
                                respuesta.objetoRespuesta = ProcesarVuelos(respuestaProvisional);
                                break;
                            case clsConstantes.Entidades.RESERVA:
                                respuesta.objetoRespuesta = ProcesarReservas(respuestaProvisional);
                                break;
                            case clsConstantes.Entidades.EVALUACION:
                                respuesta.objetoRespuesta = ProcesarEvaluaciones(respuestaProvisional);
                                break;
                            case clsConstantes.Entidades.CALIFICACION:
                                respuesta.objetoRespuesta = ProcesarCalificaciones(respuestaProvisional);
                                break;
                            default:
                                respuesta.objetoRespuesta = listaResultados;
                                break;
                        }
                    }
                    #endregion
                }
            }
            catch (Exception e)
            {
                //Retorna el objeto de respuesta erronea
                respuesta.codigoRespuesta = clsConstantes.CodigosRespuestas.CODIGOICORRECTO;
                respuesta.mensajeRespuesta = e.Message;
            }
            finally
            {
                SqlConexion.CloseConexion();
            }
            return respuesta;
        }

        #region Metodos de recorrido de las entidades
        /// <summary>
        ///     Asigna los valores de la respuesta recibida y los asigna a una lista de destinos
        /// </summary>
        /// <param name="respuestaProvisional"></param>
        /// <returns>Lista de empleados</returns>
        protected List<CapaETL.Destino> ProcesarDestinos(CapaETL.Respuesta respuestaProvisional)
        {
            List<CapaETL.Destino> resultadosDestinos = new List<CapaETL.Destino>();
            foreach (var fila in respuestaProvisional.objetoRespuesta)
            {
                CapaETL.Destino destino = new CapaETL.Destino();

                destino.codigoDestino = Convert.ToInt32(fila[0]);
                destino.destinoSalida = Convert.ToString(fila[1]);
                destino.destinoLlegada = Convert.ToString(fila[2]);
                destino.destinos = Convert.ToString(fila[3]);
                resultadosDestinos.Add(destino);
            }
            return resultadosDestinos;
        }

        /// <summary>
        ///     Asigna los valores de la respuesta recibida y los asigna a una lista de vuelos
        /// </summary>
        /// <param name="respuestaProvisional"></param>
        /// <returns>Lista de empleados</returns>
        protected List<CapaETL.Vuelo> ProcesarVuelos(CapaETL.Respuesta respuestaProvisional)
        {
            List<CapaETL.Vuelo> resultadosVuelos = new List<CapaETL.Vuelo>();
            foreach (var fila in respuestaProvisional.objetoRespuesta)
            {
                CapaETL.Vuelo vuelo = new CapaETL.Vuelo();

                vuelo.codigoVuelo = Convert.ToInt32(fila[0]);
                vuelo.codigoDestino = Convert.ToInt32(fila[1]);
                vuelo.destinos = Convert.ToString(fila[2]);
                vuelo.capacidad = Convert.ToInt32(fila[3]);
                vuelo.fechaSalida = Convert.ToDateTime(fila[4]);
                resultadosVuelos.Add(vuelo);
            }
            return resultadosVuelos;
        }

        /// <summary>
        ///     Asigna los valores de la respuesta recibida y los asigna a una lista de reservas
        /// </summary>
        /// <param name="respuestaProvisional"></param>
        /// <returns>Lista de reservas</returns>
        protected List<CapaETL.Reserva> ProcesarReservas(CapaETL.Respuesta respuestaProvisional)
        {
            List<CapaETL.Reserva> resultadosReservas = new List<CapaETL.Reserva>();
            foreach (var fila in respuestaProvisional.objetoRespuesta)
            {
                CapaETL.Reserva reserva = new CapaETL.Reserva();

                reserva.codigoReserva = Convert.ToInt32(fila[0]);
                reserva.codigoVuelo = Convert.ToInt32(fila[1]);
                reserva.destinos = Convert.ToString(fila[2]);
                reserva.fechaSalida = Convert.ToDateTime(fila[3]);
                reserva.nombreCliente = Convert.ToString(fila[4]);
                reserva.cantidadNoFumadores = Convert.ToInt32(fila[5]);
                reserva.cantidadFumadores = Convert.ToInt32(fila[6]);
                resultadosReservas.Add(reserva);
            }
            return resultadosReservas;
        }

        /// <summary>
        ///     Asigna los valores de la respuesta recibida y los asigna a una lista de reservas
        /// </summary>
        /// <param name="respuestaProvisional"></param>
        /// <returns>Lista de reservas</returns>
        protected List<CapaETL.Evaluacion> ProcesarEvaluaciones(CapaETL.Respuesta respuestaProvisional)
        {
            List<CapaETL.Evaluacion> resultadosEvaluaciones = new List<CapaETL.Evaluacion>();
            foreach (var fila in respuestaProvisional.objetoRespuesta)
            {
                CapaETL.Evaluacion evaluacion = new CapaETL.Evaluacion();

                evaluacion.codigoEvaluacion = Convert.ToInt32(fila[0]);
                evaluacion.nombre = Convert.ToString(fila[1]);
                evaluacion.descripcion = Convert.ToString(fila[2]);
                evaluacion.cantidadCalificaciones = Convert.ToInt32(fila[3]);
                resultadosEvaluaciones.Add(evaluacion);
            }
            return resultadosEvaluaciones;
        }

        /// <summary>
        ///     Asigna los valores de la respuesta recibida y los asigna a una lista de calificaciones
        /// </summary>
        /// <param name="respuestaProvisional"></param>
        /// <returns>Lista de reservas</returns>
        protected List<CapaETL.Calificacion> ProcesarCalificaciones(CapaETL.Respuesta respuestaProvisional)
        {
            List<CapaETL.Calificacion> resultadosCalificaciones = new List<CapaETL.Calificacion>();
            foreach (var fila in respuestaProvisional.objetoRespuesta)
            {
                CapaETL.Calificacion calificacion = new CapaETL.Calificacion();

                calificacion.codigoCalificacion = Convert.ToInt32(fila[0]);
                calificacion.codigoEvaluacion = Convert.ToInt32(fila[1]);
                calificacion.nombreEvaluacion = Convert.ToString(fila[2]);
                calificacion.descripcionEvaluacion = Convert.ToString(fila[3]);
                calificacion.cedulaCalificante = Convert.ToString(fila[4]);
                calificacion.calificacion = Convert.ToInt32(fila[5]);
                resultadosCalificaciones.Add(calificacion);
            }
            return resultadosCalificaciones;
        }
        #endregion
    }
}
