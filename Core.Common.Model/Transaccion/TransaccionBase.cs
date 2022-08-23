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
            Resultado = new Mensaje(10000, "OK", false, null);
            Auditoria = new Auditoria();
            Terminal = new Terminal();
            DatosApi = new DatosAPI();
            FechaHoraTransaccion = DateTime.Now;
        }
        public string TokenJWT { get; set; }
        public int CodigoTransaccion { get; set; }
        public DateTime FechaHoraTransaccion { get; set; }

        public Terminal Terminal { get; set; }
        public DatosAPI DatosApi { get; set; }
        public Mensaje Resultado { get; set; }
        public Auditoria Auditoria { get; set; }
    }
}
