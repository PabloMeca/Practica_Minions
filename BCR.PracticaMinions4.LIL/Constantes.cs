namespace BCR.PracticaMinions4.LIL
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
    public class Constantes
    {
        #region Constantes Generales
        public const string NOMBRECONEXION = "ConexionUnica";
        //Funcion JS que muestra una alerta y redirige a una pagina
        public const string SCRIPT_MENSAJE = "<script language=\"javascript\" type='text/javascript'> alert('{0}');window.location.href=\"{1}\";</script>";
        //Valor del select por defecto
        public const string OPTNOSELECCIONADO = "0";
        #endregion

        /// <summary>
        ///     Contiene los codigos de respuesta de los procedimientos.
        /// </summary>
        public struct CodigosRespuestas
        {
            public const int CODIGOCORRECTO = 0;
            public const int CODIGOICORRECTO = -1;
            public const int CODIGOVACIO = -2;
            public const int CODIGODEPENDENCIAS = -3;
        }

        /// <summary>
        ///    Nombre de las entidades del programa
        /// </summary>
        public struct Entidades
        {
            public const string DESTINO = "Destino";
            public const string VUELO = "Vuelo";
            public const string RESERVA = "Reserva";
            public const string EVALUACION = "Evaluacion";
            public const string CALIFICACION = "Calificacion";
        }

        /// <summary>
        ///     Contiene todos los nombres de procedimientos y una estructura con los parametros
        /// </summary>
        public struct Procedimientos
        {
            #region Procedimientos Destinos
            public const string INSERTARDESTINOS = "PR_Insertar_Destino";
            public const string MOSTRARDESTINOS = "PR_Mostrar_Destinos";
            public const string MODIFICARDESTINOS = "PR_Modificar_Destinos";
            public const string SELECCIONARDESTINO = "PR_Seleccionar_Destino";
            #endregion
            #region Procedimientos Vuelos
            public const string MOSTRARVUELOS = "PR_Mostrar_Vuelos";
            public const string INSERTARVUELOS = "PR_Insertar_Vuelos";
            public const string SELECCIONARVUELO = "PR_Seleccionar_Vuelo";
            public const string MODIFICARVUELO = "PR_Modificar_Vuelos";
            #endregion
            #region Procedimientos Reservas
            public const string MOSTRARRESERVAS = "PR_Mostrar_Reservas";
            public const string INSERTARRESERVAS = "PR_Insertar_Reservas";
            public const string MOSTRARDISPONIBLES = "PR_Mostrar_Disponibles";
            public const string ELIMINARRESERVAS = "PR_Eliminar_Empleados";
            #endregion
            #region Procedimientos Evaluaciones
            public const string MOSTRAREVALUACIONES = "PR_Mostrar_Evaluaciones";
            public const string INSERTAREVALUACIONES = "PR_Insertar_Evaluacion";
            #endregion
            #region Procedimientos Calificaciones
            public const string MOSTRARCALIFICACIONES = "PR_Mostrar_Calificaciones";
            public const string INSERTARCALIFICACIONES = "PR_Insertar_Calificaciones";
            #endregion
            /// <summary>
            ///     Contiene los parametros de los procedimientos
            /// </summary>
            public struct Parametros
            {
                #region Parametros Genericos
                public const string CODIGORESPUESTA = "@piCodigo";
                public const string MENSAJERESPUESTA = "@pvMensaje";
                public const string ENTIDAD = "@pvEntidad";
                #endregion
                #region Parametros Destinos
                public const string CODIGODESTINO = "@piCodigo_Destino";
                public const string DESTINOLLEGADA = "@pvDestino_Llegada";
                public const string DESTINOSALIDA = "@pvDestino_Salida";
                #endregion
                #region Parametros Vuelos
                public const string CODIGOVUELO = "@piCodigo_Vuelo";
                public const string FECHASALIDA = "@pdFecha_Salida";
                public const string HORASALIDA = "@ptHora_Salida";
                public const string CAPACIDAD = "@piCapacidad";
                #endregion
                #region Parametros Reservas
                public const string CODIGORESERVA = "@piCodigo_Reserva";
                public const string NOMBRECLIENTE = "@pvNombre_Cliente";
                public const string CANTIDADNOFUMADORES = "@piCantidad_No_Fumadores";
                public const string CANTIDADFUMADORES = "@piCantidad_Fumadores";
                #endregion
                #region Parametros Evaluaciones
                public const string NOMBREEVALUACION = "@pvNombre";
                public const string DESCRIPCIONEVALUACION = "@pvDescripcion";
                public const string CANTIDADCALIFICACIONES = "@piCantidad_Calificaciones";
                #endregion
                #region Parametros Calificaciones
                public const string CEDULACALIFICANTE = "@pvCedula_Calificante";
                public const string CALIFICACION = "@piCalificacion";
                public const string CODIGOEVALUACION = "@piCodigo_Evaluacion";
                #endregion
            }
        }

        /// <summary>
        ///     Datasets usados en los reportes
        /// </summary>
        public struct Datasets
        {
            public const string DESTINOS = "DESTINOS";
            public const string MYDATASET = "MyDataSet";
            public const string RESERVAS = "RESERVAS";
        }

        /// <summary>
        ///     Columnas de las tablas de los reportes
        /// </summary>
        public struct Columnas
        {
            #region Columnas Destinos
            public const string CODIGODESTINO = "Codigo_Destino";
            public const string DESTINOSALIDA = "Destino_Salida";
            public const string DESTINOLLEGADA = "Destino_Llegada";
            public const string DESTINOS = "Destinos";
            #endregion
            #region Columnas Reservas
            public const string CODIGORESERVA = "Codigo_Reserva";
            public const string CODIGOVUELO = "Codigo_Vuelo";
            public const string FECHASALIDA = "Fecha_Salida";
            public const string NOMBRECLIENTE = "Nombre_Cliente";
            public const string CANTIDADNOFUMADORES = "Cantidad_No_Fumadores";
            public const string CANTIDADFUMADORES = "Cantidad_Fumadores";
            #endregion
        }

        /// <summary>
        ///     Rutas de los reportes
        /// </summary>
        public struct Reportes
        {
            public const string DESTINOS = "Reportes/Destinos.rdlc";
            public const string RESERVAS = "Reportes/Reservas.rdlc";
        }
    }
}
