using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.Transaccion.Base
{
    public class Link
    {

        public Link() { }

        public Guid Id { get; set; }
        public string Accion { get; set; }
        public string HRef { get; set; }
        public string Rel { get; set; }
        public string Type { get; set; }

    }
}
