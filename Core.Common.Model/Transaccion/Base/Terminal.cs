using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.Transaccion.Base
{
    public class Terminal
    {
        public Terminal() { }

        public string DireccionIP { get; set; }
        public string DireccionIPServidor { get; set; }
        public string NombreTerminal { get; set; }

    }
}
