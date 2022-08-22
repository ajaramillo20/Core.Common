using Core.Common.BusinessLogic.Base;
using Core.Common.Model.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.BusinessLogic.ProcessTemplate
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
