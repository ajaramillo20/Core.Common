using Core.Common.Model.Transaccion;
using Core.Common.ProcessTemplate.InternalBusinessLogic.Base;

namespace Core.Common.ProcessTemplate.InternalBusinessLogic
{
    /// <summary>
    /// Métodos para el encadenamiento de eventos que obtiene la lista completa de registros de la transaccion (CRUDProcessTemplate)
    /// </summary>
    /// <typeparam name="Request">Objeto de solicitud</typeparam>
    /// <typeparam name="Response">Objeto de respuesta</typeparam>
    public interface IObtenerTodos<Request, Response> : IBaseProcessTemplate<Request, Response>
        where Request : TransaccionBase
        where Response : class, new()
    {

        void AgregarInformacion(Request objetoTransaccional);

        void ValidarInformacion(Request objetoTransaccional);


    }
}
