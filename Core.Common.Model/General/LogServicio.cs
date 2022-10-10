using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.General
{
    public class LogServicio
    {
        /// <summary>
        /// Información u objeto que se requiera guardar en base de datos
        /// </summary>
        public string Accion { get; set; }

        /// <summary>
        /// Nombre de espacio
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Tipo de mensaje, puede ser de entrada, salida, error
        /// </summary>
        public TipoMensajeLog TipoMensaje { get; set; }

        /// <summary>
        /// Fecha del log generado
        /// </summary>
        public DateTime Fecha { get; set; }
        
        /// <summary>
        /// Codigo Credencial
        /// </summary>
        public string CodigoCredencial { get; set; }

        /// <summary>
        /// Objeto Json
        /// </summary>
        public string ObjetoTrxJson { get; set; }
    }
}
