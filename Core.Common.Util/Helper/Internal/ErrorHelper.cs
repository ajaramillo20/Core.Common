using Core.Common.DataAccess.Procesos.API;
using Core.Common.DataAccess.Procesos.Errores;
using Core.Common.Model.Transaccion.Base;

namespace Core.Common.Util.Helper.Internal
{
    public static class ErrorHelper
    {
        public static Mensaje ObtenerMensajeRespuesta(int codigoInternoRespuesta)
        {
            var errorMicroservicio = ObtenerErrorMicroservicioDAL.Execute(codigoInternoRespuesta);
            var mensaje = new Mensaje(errorMicroservicio.CodigoInterno, errorMicroservicio.MensajeError, true, errorMicroservicio.Modulo);
            return mensaje;
        }
    }
}
