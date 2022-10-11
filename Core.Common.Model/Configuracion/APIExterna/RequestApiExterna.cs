using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.Configuracion.APIExterna
{
    public class RequestApiExterna
    {
        public string Url { get; set; }
        public string Metodo { get; set; }
        public string ContentType { get; set; }
        public string CredencialCodigo { get; set; }
        public string Content { get; set; }
        public List<ParametrosPeticion> Headers { get; set; }

        public List<ParametrosPeticion> QueryParams { get; set; }
    }
    public class ParametrosPeticion
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }
    }
}
