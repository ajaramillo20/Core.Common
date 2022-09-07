using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.Configuracion.API
{
    public class APIRest
    {
        public APIRest()
        {
            ObjetoRespuesta = new ObjetoRespuesta();
        }

        public string NombreAPIRest { get; set; }
        public string NombreControlador { get; set; }
        public string NombreAccion { get; set; }

        public ObjetoRespuesta ObjetoRespuesta { get; set; }
    }


    public class ObjetoRespuesta 
    {
        public ObjetoRespuesta()
        {
            ListaPropiedades = new List<Propiedades>();
        }

        public string JsonSchema { get; set; }
        public string NombreObjeto { get; set; }
        public List<Propiedades> ListaPropiedades { get; set; }

    }

    public class Propiedades {
        public string PropiedadOrigen { get; set; }
        public string PropiedadDestino { get; set; }
    }
}
