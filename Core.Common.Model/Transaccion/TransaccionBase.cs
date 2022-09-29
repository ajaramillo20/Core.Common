using Core.Common.Model.Transaccion.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.Transaccion
{
    public abstract class TransaccionBase
    {
        public TransaccionBase()
        {
            Respuesta = new Mensaje(10000, "OK", false, string.Empty,10000);
            Auditoria = new Auditoria();
            Terminal = new Terminal();
            Endpoint = new Endpoint();
            FechaHoraTransaccion = DateTime.Now;
        }
        public string TokenJWT { get; set; }
        public int CodigoTransaccion { get; set; }
        public DateTime FechaHoraTransaccion { get; set; }

        public Terminal Terminal { get; set; }
        public Endpoint Endpoint { get; set; }
        public Mensaje Respuesta { get; set; }
        public Auditoria Auditoria { get; set; }
        public string Credenciales { get; set; }
    }
}
