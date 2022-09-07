using Core.Common.Model.Transaccion;
using Core.Common.ProcessTemplate.InternalBusinessLogic.Base;

namespace Core.Common.ProcessTemplate.InternalBusinessLogic
{
    public interface IProcesarTransaccion<Request, Response> : IBaseProcessTemplate<Request, Response>
        where Request : TransaccionBase
        where Response : class, new()
    {

        void AgregarInformacion(Request objetoTransaccional);

        void ValidarInformacion(Request objetoTransaccional);

        void AutorizarTransaccion(Request objetoTransaccional);

        void EjecutarTransaccion(Request objetoTransaccional);

        void ReversarTransaccion(Request objetoTransaccional);

    }
}
