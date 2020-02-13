namespace BCR.PracticaMinions4.ETL
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
    public class Destino
    {
        /// <summary>
        ///     Se inicializan los atributos del destino.
        /// </summary>
        public Destino()
        {
            codigoDestino = int.MinValue;
            destinoSalida = string.Empty;
            destinoLlegada = string.Empty;
            destinos = string.Empty;
        }

        public int codigoDestino { get; set; }
        public string destinoSalida { get; set; }
        public string destinoLlegada { get; set; }
        public string destinos { get; set; }
    }
}
