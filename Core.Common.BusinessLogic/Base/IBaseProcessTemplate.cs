using Core.Common.Model.General;
using Core.Common.Model.Transaccion;
using Core.Common.Model.Transaccion.Base;

namespace Core.Common.BusinessLogic.Base
{
    public interface IBaseProcessTemplate<Request, Response>
        where Request : TransaccionBase
        where Response : class, new()
    {
        Response ArmarObjetoRespuesta(Request objetoTransaccional); 

        Response ArmaraPaginaRespuesta(Request objetoTransaccional);
        

        ColeccionObjetos<Link> ArmarLinkRespuesta(Request objetoTransaccional)
        {
            return new ColeccionObjetos<Link>()
            {
                new Link() {
                    Id = Guid.Parse(ConstantesRest.GUID_EMPTY),
                    Accion = objetoTransaccional.DatosApi.Accion,
                    HRef = objetoTransaccional.DatosApi.UrlBase,
                    Rel = objetoTransaccional.DatosApi.Controlador,
                    Type =  objetoTransaccional.DatosApi.Metodo,
                }
            };
        }

        Meta ArmarMetaRespuesta(Request objetoTransaccional)
        {
            return new Meta()
            {
                TotalPaginas = 1,
                FechaInicial = objetoTransaccional.FechaHoraTransaccion,
                FechaFinal = DateTime.Now,
            };
        }

    }
}
