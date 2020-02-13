using System;


namespace BCR.PracticaMinions4.ETL
{
    /// <summary>
    ///     <createddate>2020-02-04</createddate>
    ///     <company>Grupo Babel</company>
    ///     <lastmodificationdate>2020-02-04</lastmodificationdate>
    ///     <lastmodificationdescription>
    ///         Se agregaron los comentarios a la clase.
    ///     </lastmodificationdescription>
    ///     <lastmodifierautor>Jeison Jiménez</lastmodifierautor>
    /// </summary>
    public class Reserva
    {
        /// <summary>
        ///     Inicializa los atributos
        /// </summary>
        public Reserva()
        {
            codigoReserva = int.MinValue;
            codigoVuelo = int.MinValue;
            destinos = string.Empty;
            nombreCliente = string.Empty;
            cantidadNoFumadores = int.MinValue;
            cantidadFumadores = int.MinValue;
            fechaSalida = DateTime.MinValue;
        }

        public int codigoReserva { get; set; }
        public int codigoVuelo { get; set; }
        public string destinos { get; set; }
        public string nombreCliente { get; set; }
        public int cantidadNoFumadores { get; set; }
        public int cantidadFumadores { get; set; }

        public DateTime fechaSalida { get; set; }
    }
}
