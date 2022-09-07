using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.Transaccion.Base
{
    public class Endpoint
    {
        public Endpoint() { }

        public string LogicaInyectada { get; set; }
        public string Accion { get; set; }
        public string Controlador { get; set; }
        public string Metodo { get; set; }
        public string NombreAPIRest { get; set; }
        public string UrlBase { get; set; }

    }
}
