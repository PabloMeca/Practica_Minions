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
    public class Respuesta
    {
        /// <summary>
        ///     Inicializa los atributos
        /// </summary>
        public Respuesta()
        {
            objetoRespuesta = string.Empty;
            codigoRespuesta = int.MinValue;
            mensajeRespuesta = string.Empty;
        }

        public dynamic objetoRespuesta { get; set; }
        public int codigoRespuesta { get; set; }
        public string mensajeRespuesta { get; set; }
    }
}
