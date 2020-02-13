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
    public class Calificacion
    {

        /// <summary>
        ///     Inicializa los atributos
        /// </summary>
        public Calificacion()
        {
            codigoCalificacion = int.MinValue;
            codigoEvaluacion = int.MinValue;
            nombreEvaluacion = string.Empty;
            descripcionEvaluacion = string.Empty;
            cedulaCalificante = string.Empty;
            calificacion = int.MinValue;
        }

        public int codigoCalificacion { get; set; }
        public int codigoEvaluacion { get; set; }
        public string nombreEvaluacion { get; set; }
        public string descripcionEvaluacion { get; set; }
        public string cedulaCalificante { get; set; }
        public int calificacion { get; set; }
    }
}
