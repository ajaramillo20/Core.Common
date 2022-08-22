using Core.Common.BusinessLogic.Base;
using Core.Common.Model.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.BusinessLogic.ProcessTemplate
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
