using Core.Common.BusinessLogic.Base;
using Core.Common.Model.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.BusinessLogic.ProcessTemplate
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
