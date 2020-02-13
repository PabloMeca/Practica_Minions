using BCR.PracticaMinions4.ETL;
using System;
using System.Collections.Generic;
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
    public class VuelosController : Controller
    {
        #region Inicializacion de variables
        CapaETL.Respuesta respuesta = new CapaETL.Respuesta();
        CapaBLL.Destinos bllDestinos = new CapaBLL.Destinos();
        CapaBLL.Vuelos bllVuelos = new CapaBLL.Vuelos();
        CapaBLL.Reservas bllReservas = new CapaBLL.Reservas();
        #endregion

        #region Inicio
        /// <summary>
        ///     Método que retorna una vista
        /// </summary>
        /// <returns>Vista inicial</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     Método que retorna una vista
        /// </summary>
        /// <returns>Vista de inicio de los vuelos</returns>
        public ActionResult InicioVuelos()
        {
            return View();
        }
        #endregion

        #region Destinos
        /// <summary>
        ///     Método que retorna una vista, con un modelo de destinos
        /// </summary>
        /// <returns>Vista de destinos</returns>
        public ActionResult Destinos()
        {
            try
            {
                return View(bllDestinos.MostrarDestinos().objetoRespuesta);
            }
            catch(Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Destinos");
                return Content(CodigoJavaScript);
            }
        }

        /// <summary>
        ///     Método que retorna una vista donde se agregan destinos
        /// </summary>
        /// <returns>Vista donde se agregan destinos</returns>
        public ActionResult AgregarDestinos()
        {
            return View();
        }

        /// <summary>
        ///     Método que inserta un destino y retorna un codigo de JS que muestra un mensaje de respuesta
        /// </summary>
        /// <param name="txtDestinoSalida"></param>
        /// <param name="txtDestinoLlegada"></param>
        /// <returns>Codigo javascript</returns>
        public ActionResult InsertarDestino(string txtDestinoSalida, string txtDestinoLlegada)
        {
            try
            {
                string CodigoJavaScript;
                if (string.IsNullOrEmpty(txtDestinoSalida) || string.IsNullOrEmpty(txtDestinoLlegada))
                {
                    //Se le da formato a la funcion javascript de retorno
                    CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjErrorCamposVacios, "/Vuelos/AgregarDestinos");
                }
                else
                {
                    CapaETL.Destino destino = new CapaETL.Destino();
                    destino.destinoSalida = txtDestinoSalida;
                    destino.destinoLlegada = txtDestinoLlegada;

                    respuesta = bllDestinos.InsertarDestinos(destino);
                    if (respuesta.codigoRespuesta == clsConstantes.CodigosRespuestas.CODIGOCORRECTO)
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjDestinoAgregado, "/Vuelos/Destinos");
                    }
                    else
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, respuesta.mensajeRespuesta, "/Vuelos/Destinos");
                    }
                }
                return Content(CodigoJavaScript);
            }
            catch(Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Destinos");
                return Content(CodigoJavaScript);
            }           
        }

        /// <summary>
        ///     Método que devuelve una vista con un modelo de destinos, donde se modifica un usuario
        /// </summary>
        /// <param name="idDestino"></param>
        /// <returns></returns>
        public ActionResult ModificarDestino(int idDestino)
        {
            try
            {
                CapaETL.Destino destino = new CapaETL.Destino();
                destino.codigoDestino = idDestino;
                return View(bllDestinos.SeleccionarDestino(destino).objetoRespuesta);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Destinos");
                return Content(CodigoJavaScript);
            }
        }

        /// <summary>
        ///     Método que modifica un destino y retorna un codigo de JS que muestra un mensaje de respuesta
        /// </summary>
        /// <param name="txtCodigo"></param>
        /// <param name="txtDestinoSalida"></param>
        /// <param name="txtDestinoLlegada"></param>
        /// <returns>Vista de actualizar destinos</returns>
        public ActionResult ActualizarDestino(string txtCodigo, string txtDestinoSalida, string txtDestinoLlegada)
        {
            try
            {
                string CodigoJavaScript;
                if (string.IsNullOrEmpty(txtDestinoSalida) || string.IsNullOrEmpty(txtDestinoLlegada))
                {
                    //Se le da formato a la funcion javascript de retorno
                    CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjErrorCamposVacios, "/Vuelos/AgregarDestinos");
                }
                else
                {
                    CapaETL.Destino destino = new CapaETL.Destino();
                    destino.codigoDestino = Convert.ToInt32(txtCodigo);
                    destino.destinoSalida = txtDestinoSalida;
                    destino.destinoLlegada = txtDestinoLlegada;

                    respuesta = bllDestinos.ModificarDestino(destino);
                    if (respuesta.codigoRespuesta == clsConstantes.CodigosRespuestas.CODIGOCORRECTO)
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjDestinoModificado, "/Vuelos/Destinos");
                    }
                    else
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, respuesta.mensajeRespuesta, "/Vuelos/Destinos");
                    }
                }
                return Content(CodigoJavaScript);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Destinos");
                return Content(CodigoJavaScript);
            }
        }
        #endregion

        #region Vuelos
        /// <summary>
        ///     Método de vista de inicio de los vuelos
        /// </summary>
        /// <returns>Vista con los vuelos</returns>
        public ActionResult Vuelos()
        {
            try
            {
                return View(bllVuelos.MostrarVuelos().objetoRespuesta);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Vuelos");
                return Content(CodigoJavaScript);
            }
        }

        /// <summary>
        ///     Retorna una vista donde se agregan los vuelos
        /// </summary>
        /// <returns>Vista agregar vuelos</returns>
        public ActionResult AgregarVuelos()
        {
            try
            {
                return View(bllDestinos.MostrarDestinos().objetoRespuesta);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Vuelos");
                return Content(CodigoJavaScript);
            }
        }

        /// <summary>
        ///     Método que inserta los vuelos 
        /// </summary>
        /// <param name="txtCapacidad"></param>
        /// <param name="txtFecha"></param>
        /// <param name="optDestinos"></param>
        /// <returns>Codigo JS con mensaje de respuesta</returns>
        public ActionResult InsertarVuelos(string txtCapacidad, string txtFecha, string optDestinos)
        {
            try
            {
                string CodigoJavaScript;
                if (string.IsNullOrEmpty(txtCapacidad) || string.IsNullOrEmpty(txtFecha) || string.IsNullOrEmpty(optDestinos))
                {
                    //Se le da formato a la funcion javascript de retorno
                    CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjErrorCamposVacios, "/Vuelos/AgregarVuelos");
                }
                else
                {
                    CapaETL.Vuelo vuelo = new CapaETL.Vuelo();
                    vuelo.capacidad = Convert.ToInt32(txtCapacidad);
                    vuelo.fechaSalida = Convert.ToDateTime(txtFecha);
                    vuelo.codigoDestino = Convert.ToInt32(optDestinos);

                    respuesta = bllVuelos.InsertarVuelos(vuelo);
                    if (respuesta.codigoRespuesta == clsConstantes.CodigosRespuestas.CODIGOCORRECTO)
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjVueloAgregado, "/Vuelos/Vuelos");
                    }
                    else
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, respuesta.mensajeRespuesta, "/Vuelos/Vuelos");
                    }
                }
                return Content(CodigoJavaScript);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Vuelos");
                return Content(CodigoJavaScript);
            }
        }

        /// <summary>
        ///     Metodo que retorna una vista para modificar vuelos y que tiene un view model con una lista de destinos y vuelos
        /// </summary>
        /// <param name="idVuelo"></param>
        /// <returns>Vista modificar vuelos</returns>
        public ActionResult ModificarVuelo(int idVuelo)
        {
            try
            {
                CapaETL.Vuelo vuelo = new CapaETL.Vuelo();
                vuelo.codigoVuelo = idVuelo;
                ViewModel viewModel = new ViewModel();
                //Modelos para utilizar en la vista
                viewModel.listaDestinos = bllDestinos.MostrarDestinos().objetoRespuesta;
                viewModel.listaVuelos = bllVuelos.SeleccionarVuelo(vuelo).objetoRespuesta;
                return View(viewModel);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Vuelos");
                return Content(CodigoJavaScript);
            }
        }

        /// <summary>
        ///     Metodo que modifica los vuelos
        /// </summary>
        /// <param name="txtCodigoVuelo"></param>
        /// <param name="txtCapacidad"></param>
        /// <param name="txtFecha"></param>
        /// <param name="optDestinos"></param>
        /// <returns>Codigo JS con mensaje de respuesta</returns>
        public ActionResult ActualizarVuelo(string txtCodigoVuelo, string txtCapacidad, string txtFecha, string optDestinos)
        {
            try
            {
                string CodigoJavaScript;
                if (string.IsNullOrEmpty(txtCapacidad) || string.IsNullOrEmpty(txtFecha) || string.IsNullOrEmpty(optDestinos))
                {
                    //Se le da formato a la funcion javascript de retorno
                    CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjErrorCamposVacios, "/Vuelos/ModificarVuelo");
                }
                else
                {
                    CapaETL.Vuelo vuelo = new CapaETL.Vuelo();
                    vuelo.codigoVuelo = Convert.ToInt32(txtCodigoVuelo);
                    vuelo.capacidad = Convert.ToInt32(txtCapacidad);
                    vuelo.fechaSalida = Convert.ToDateTime(txtFecha);
                    vuelo.codigoDestino = Convert.ToInt32(optDestinos);

                    respuesta = bllVuelos.ModificarVuelo(vuelo);
                    if (respuesta.codigoRespuesta == clsConstantes.CodigosRespuestas.CODIGOCORRECTO)
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjVueloModificado, "/Vuelos/Vuelos");
                    }
                    else
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, respuesta.mensajeRespuesta, "/Vuelos/Vuelos");
                    }
                }
                return Content(CodigoJavaScript);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Vuelos");
                return Content(CodigoJavaScript);
            }
        }
        #endregion

        #region Reservas
        /// <summary>
        ///     Metodo que retorna una vista de inicio de reservas
        /// </summary>
        /// <returns>Vista de reservas</returns>
        public ActionResult Reservas()
        {
            try
            {
                return View(bllReservas.MostrarReservas().objetoRespuesta);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Reservas");
                return Content(CodigoJavaScript);
            }
        }

        /// <summary>
        ///    Metodo que retorna una vista donde se agregan reservas 
        /// </summary>
        /// <returns></returns>
        public ActionResult AgregarReservas()
        {
            try
            {
                return View(bllVuelos.MostrarVuelos().objetoRespuesta);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Reservas");
                return Content(CodigoJavaScript);
            }
        }

        /// <summary>
        ///     Metodo que inserta las reservas
        /// </summary>
        /// <param name="txtNombre"></param>
        /// <param name="txtFumadores"></param>
        /// <param name="txtNofumadores"></param>
        /// <param name="optVuelos"></param>
        /// <returns>Codigo JS con mensaje de respuesta</returns>
        public ActionResult InsertarReservas(string txtNombre, string txtFumadores, string txtNofumadores, string optVuelos)
        {
            try
            {
                string CodigoJavaScript;
                if (string.IsNullOrEmpty(txtNombre) || string.IsNullOrEmpty(txtFumadores) || string.IsNullOrEmpty(txtNofumadores))
                {
                    //Se le da formato a la funcion javascript de retorno
                    CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjErrorCamposVacios, "/Vuelos/AgregarReservas");
                }
                else if (optVuelos == clsConstantes.OPTNOSELECCIONADO)
                {
                    //Se le da formato a la funcion javascript de retorno
                    CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjVueloNoSeleccionado, "/Vuelos/AgregarReservas");
                }
                else
                {
                    CapaETL.Reserva reserva = new CapaETL.Reserva();
                    reserva.nombreCliente = txtNombre;
                    reserva.cantidadFumadores = Convert.ToInt32(txtFumadores);
                    reserva.cantidadNoFumadores = Convert.ToInt32(txtNofumadores);
                    reserva.codigoVuelo = Convert.ToInt32(optVuelos);

                    respuesta = bllReservas.InsertarReservas(reserva);
                    if (respuesta.codigoRespuesta == clsConstantes.CodigosRespuestas.CODIGOCORRECTO)
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjReservaAgregada, "/Vuelos/Reservas");
                    }
                    else
                    {
                        //Se le da formato a la funcion javascript de retorno
                        CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, respuesta.mensajeRespuesta, "/Vuelos/Reservas");
                    }
                }
                return Content(CodigoJavaScript);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Reservas");
                return Content(CodigoJavaScript);
            }
        }

        /// <summary>
        ///     Metodo que elimina las reservas
        /// </summary>
        /// <param name="idReserva"></param>
        /// <returns>Codigo JS con mensaje de respuesta</returns>
        public ActionResult CancelarReservas(int idReserva)
        {
            try
            {
                string CodigoJavaScript;
                CapaETL.Reserva reserva = new CapaETL.Reserva();
                reserva.codigoReserva = idReserva;
                respuesta = bllReservas.EliminarReservas(reserva);
                if (respuesta.codigoRespuesta == clsConstantes.CodigosRespuestas.CODIGOCORRECTO)
                {
                    //Se le da formato a la funcion javascript de retorno
                    CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, Mensajes.msjReservaEliminada, "/Vuelos/Reservas");
                }
                else
                {
                    //Se le da formato a la funcion javascript de retorno
                    CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, respuesta.mensajeRespuesta, "/Vuelos/Reservas");
                }
                return Content(CodigoJavaScript);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Reservas");
                return Content(CodigoJavaScript);
            }
        }
        
        /// <summary>
        ///     Metodo que consulta los campos disponibles en un vuelo
        /// </summary>
        /// <param name="idVuelo"></param>
        /// <returns>Json con los campos disponibles</returns>
        [HttpPost]
        public ActionResult Disponibles(int idVuelo)
        {
            try
            {
                Reserva reserva = new Reserva();
                reserva.codigoVuelo = idVuelo;
                respuesta = bllReservas.Disponibles(reserva);
                DisponiblesModel disponibles = new DisponiblesModel();
                // Asigna los campos disponibles que trae la respuesta a un modelo
                disponibles.disponiblesFumadores = respuesta.objetoRespuesta[0][0];
                disponibles.disponiblesNoFumadores = respuesta.objetoRespuesta[0][1];
                disponibles.capacidad = respuesta.objetoRespuesta[0][2];
                return Json(disponibles);
            }
            catch (Exception ex)
            {
                string CodigoJavaScript = string.Format(clsConstantes.SCRIPT_MENSAJE, ex.Message, "/Vuelos/Reservas");
                return Content(CodigoJavaScript);
            }
        }
        #endregion
    }

    #region Modelos
    /// <summary>
    ///     <createddate>2020-02-05</createddate>
    ///     <company>Grupo Babel</company>
    ///     <lastmodificationdate>2020-02-05</lastmodificationdate>
    ///     <lastmodificationdescription>
    ///         Se agregaron los comentarios a la clase.
    ///     </lastmodificationdescription>
    ///     <lastmodifierautor>Jeison Jiménez</lastmodifierautor>
    /// </summary>
    public class ViewModel
    {
        /// <summary>
        ///     Inicializa los atributos
        /// </summary>
        public ViewModel()
        {
            listaDestinos = new List<Destino>();
            listaVuelos = new List<Vuelo>();
        }

        public List<BCR.PracticaMinions4.ETL.Destino> listaDestinos { get; set; }
        public List<BCR.PracticaMinions4.ETL.Vuelo> listaVuelos { get; set; }
    }

    /// <summary>
    ///     <createddate>2020-02-05</createddate>
    ///     <company>Grupo Babel</company>
    ///     <lastmodificationdate>2020-02-05</lastmodificationdate>
    ///     <lastmodificationdescription>
    ///         Se agregaron los comentarios a la clase.
    ///     </lastmodificationdescription>
    ///     <lastmodifierautor>Jeison Jiménez</lastmodifierautor>
    /// </summary>
    public class DisponiblesModel
    {
        /// <summary>
        ///     Inicializa los atributos
        /// </summary>
        public DisponiblesModel()
        {
            disponiblesFumadores = int.MinValue;
            disponiblesNoFumadores = int.MinValue;
            capacidad = int.MinValue;
        }

        public int disponiblesFumadores { get; set; }
        public int disponiblesNoFumadores { get; set; }
        public int capacidad { get; set; }
    }
    #endregion
}