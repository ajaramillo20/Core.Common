using Core.Common.BusinessLogic.Base;
using Core.Common.Model.Transaccion;

namespace Core.Common.BusinessLogic.ProcessTemplate
{
    /// <summary>
    /// Métodos para el encadenamiento de eventos que obtiene un solo registro de la transaccion (CRUDProcessTemplate)
    /// </summary>
    /// <typeparam name="Request"></typeparam>
    /// <typeparam name="Response"></typeparam>
    public interface IObtener<Request, Response> : IBaseProcessTemplate<Request, Response>
        where Request : TransaccionBase
        where Response : class, new()
    {
        void AgregarInformacion(Request objetoTransaccional);

        void ValidarInformacion(Request objetoTransaccional);

    }
}
