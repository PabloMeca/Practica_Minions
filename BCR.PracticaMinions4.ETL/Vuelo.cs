using System;

namespace BCR.PracticaMinions4.ETL
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
    public class Vuelo
    {
        /// <summary>
        ///     Inicializa los atributos
        /// </summary>
        public Vuelo()
        {
            codigoVuelo = int.MinValue;
            codigoDestino = int.MinValue;
            capacidad = int.MinValue;
            fechaSalida = DateTime.MinValue;
            destinos = string.Empty;
        }

        public int codigoVuelo { get; set; }
        public int codigoDestino { get; set; }
        public int capacidad { get; set; }
        public DateTime fechaSalida { get; set; }
        public string destinos { get; set; }
    }
}
