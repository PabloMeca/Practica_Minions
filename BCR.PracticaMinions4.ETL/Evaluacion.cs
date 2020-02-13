namespace BCR.PracticaMinions4.ETL
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
    public class Evaluacion
    {
        /// <summary>
        ///     Inicializa los atributos
        /// </summary>
        public Evaluacion()
        {
            codigoEvaluacion = int.MinValue;
            nombre = string.Empty;
            descripcion = string.Empty;
            cantidadCalificaciones = int.MinValue;
        }

        public int codigoEvaluacion { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int cantidadCalificaciones { get; set; }
    }
}
