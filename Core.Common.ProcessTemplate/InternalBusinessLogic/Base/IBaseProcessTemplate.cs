using Core.Common.Model.General;
using Core.Common.Model.Transaccion;
using Core.Common.Model.Transaccion.Base;
using Core.Common.Util.Helper.Internal;

namespace Core.Common.ProcessTemplate.InternalBusinessLogic.Base
{
    public interface IBaseProcessTemplate<Request, Response>
        where Request : TransaccionBase
        where Response : class, new()
    {
        Response ArmarObjetoRespuesta(Request objetoTransaccional)
        {
            try
            {
                //ArmarLinkRespuesta(objetoTransaccional);
                //objetoTransaccional.ArmarMetaRespuesta(objetoTransaccional);
                if (objetoTransaccional.Respuesta.CodigoRespuesta == (int)EnumError.OperacionExitosa)
                {
                    Response respuesta = new Response();
                    return MapHelper.MapeoDinamicoRespuesta(objetoTransaccional, respuesta, objetoTransaccional.Endpoint.LogicaInyectada);
                }
                return null;
            }
            catch (Exception)
            {
                objetoTransaccional.Respuesta = ErrorHelper.ObtenerMensajeRespuesta((int)EnumErrorComponentesComunes.ErrorProcessTemplate);
                return null;
            }

        }


        ColeccionObjetos<Link> ArmarLinkRespuesta(Request objetoTransaccional)
        {
            return new ColeccionObjetos<Link>()
            {
                new Link() {
                    Id = Guid.Parse(ConstantesRest.GUID_EMPTY),
                    Accion = objetoTransaccional.Endpoint.Accion,
                    HRef = objetoTransaccional.Endpoint.UrlBase,
                    Rel = objetoTransaccional.Endpoint.Controlador,
                    Type =  objetoTransaccional.Endpoint.Metodo,
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


        //Mensaje ArmarMensajeRespuesta(Request objetoTransaccional)
        //{
        //    if (objetoTransaccional.Respuesta.CodigoRespuesta == (int)EnumError.OperacionExitosa)
        //    {
        //        return new Mensaje((int)EnumError.OperacionExitosa, "Operacion Exitosa.", false, "N/A");
        //    }
        //    return new Mensaje();//ObtenerMensajeRespuesta(objetoTransaccional.Respuesta.CodigoInternoRespuesta); 
        //}

    }
}
