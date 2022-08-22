using Core.Common.Model.General;

namespace Core.Common.Model.Transaccion.Base
{
    public class Resultado
    {

        public Resultado()
        {
            Error = "";
            EstadoProceso = EstadoProceso.OK;
            Mensaje = "OK";
        }
        public string Mensaje { get; set; }

        public string Error { get; set; }

        public EstadoProceso EstadoProceso { get; set; }
    }
}
