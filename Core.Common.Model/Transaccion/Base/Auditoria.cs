using System;

namespace Core.Common.Model.Transaccion.Base
{
    public class Auditoria
    {

        public Auditoria()
        {

        }
        public DateTime FechaProceso { get; set; }

        public string Modulo { get; set; }

        public string IPEquipo { get; set; }
    }
}
