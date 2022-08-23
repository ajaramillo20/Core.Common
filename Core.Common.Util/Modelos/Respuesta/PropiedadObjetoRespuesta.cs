using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Util.Modelos.Respuesta
{
    internal class PropiedadObjetoRespuesta
    {
        public PropiedadObjetoRespuesta()
        {
        }

        public string Destino { get; set; }

        public int IdControladorAccion { get; set; }

        public int IdObjetoRespuesta { get; set; }

        public string PropiedadOrigen { get; set; }
        public string PropiedadDestino { get; set; }

        public string JsonSchema { get; set; }
    }
}
