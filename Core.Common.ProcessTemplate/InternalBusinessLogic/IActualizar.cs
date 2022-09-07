using Core.Common.Model.Transaccion;
using Core.Common.ProcessTemplate.InternalBusinessLogic.Base;

namespace Core.Common.ProcessTemplate.InternalBusinessLogic
{
    public interface IActualizar<Request, Response> : IBaseProcessTemplate<Request, Response>
        where Request : TransaccionBase
        where Response : class, new()
    {

        void AgregarInformacion(Request objetoTransaccional);

        void ValidarInformacion(Request objetoTransaccional);

        void HomologarInformacion(Request objetoTransaccional);

        void ActualizarInformacion(Request objetoTransaccional);


    }
}
