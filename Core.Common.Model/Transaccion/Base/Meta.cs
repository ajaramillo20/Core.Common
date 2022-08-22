using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.Transaccion.Base
{
    /// <summary>
    /// Clase para que establece el tiempo de una transacción
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Meta() { }

        /// <summary>
        /// Número total de páginas.
        /// </summary>
        public int TotalPaginas { get; set; }

        /// <summary>
        /// Fecha inicial de ejecución del proceso.
        /// </summary>
        public DateTime FechaInicial { get; set; }

        /// <summary>
        /// Fecha final de ejecución del proceso.
        /// </summary>
        public DateTime FechaFinal { get; set; }

    }
}
