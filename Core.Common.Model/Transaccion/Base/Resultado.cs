using Core.Common.Model.General;

namespace Core.Common.Model.Transaccion.Base
{
    public class Resultado
    {

        public Resultado()
        {
            Error = "";
            EstadoProceso = EnumEstadoProceso.OK;
            Mensaje = "OK";
        }
        public string Mensaje { get; set; }

        public string Error { get; set; }

        public EnumEstadoProceso EstadoProceso { get; set; }
    }
}
