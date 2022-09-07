using Core.Common.DataAccess.Procesos.API;
using Core.Common.Model.Configuracion.API;
using Core.Common.Model.General;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Common.Util.Helper.Internal
{
    public static class MapHelper
    {
        private const string NOMBRE_VARIABLE_LOGICA_INYECTADA = "Endpoint.LogicaInyectada";

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="transaccion"></param>
        /// <param name="respuesta"></param>
        /// <returns></returns>
        public static R MapeoDinamicoRespuesta<T, R>(T transaccion, R respuesta, string logica)
        {
            try
            {              
                var result = ObtenerDatosApiControladorAccionDAL.Execute(ObtenerLogicaInyectada(transaccion));
                return MapeoDinamicoPropiedades(transaccion, respuesta, result.ObjetoRespuesta.ListaPropiedades);
            }
            catch (Exception ex)
            {
                return default(R);
            }
        }


        private static string ObtenerLogicaInyectada<T>(T transaccion)
        {
            JObject objOrigen = JObject.Parse(JsonConvert.SerializeObject(transaccion));
            return objOrigen.SelectToken(NOMBRE_VARIABLE_LOGICA_INYECTADA).ToString();
        }

        private static R MapeoDinamicoPropiedades<T, R>(T transaccion, R respuesta, List<Propiedades> propiedades) 
        {
            JObject objOrigen = JObject.Parse(JsonConvert.SerializeObject(transaccion));
            JObject objDestino = JObject.Parse(JsonConvert.SerializeObject(respuesta));

            System.Threading.Tasks.Parallel.ForEach(propiedades, mapeo =>
            {
                JToken origen = objOrigen.SelectToken(mapeo.PropiedadOrigen);
                JToken destino = objDestino.SelectToken(mapeo.PropiedadDestino);

                if (!string.IsNullOrEmpty(mapeo.PropiedadOrigen) && !string.IsNullOrEmpty(mapeo.PropiedadDestino))
                {
                    if (origen.Type != destino.Type)
                    {
                        if (origen.Type.ToString().Equals(EnumMapType.Array.ToString(), StringComparison.CurrentCulture) &&
                            destino.Type.ToString().Equals(EnumMapType.Array.ToString(), StringComparison.CurrentCulture))
                        {
                            JToken valor = objOrigen.SelectToken(mapeo.PropiedadOrigen).FirstOrDefault();
                            objDestino.SelectToken(mapeo.PropiedadDestino).Replace(valor);
                        }
                        else if (origen.Type.ToString().Equals(EnumMapType.Object.ToString(), StringComparison.CurrentCulture) &&
                            destino.Type.ToString().Equals(EnumMapType.Object.ToString(), StringComparison.CurrentCulture))
                        {
                            string valor = String.Format("", objOrigen.SelectToken(mapeo.PropiedadOrigen).ToString());
                            objDestino.SelectToken(mapeo.PropiedadDestino).Replace(valor);
                        }
                        else
                        {
                            JToken valor = objOrigen.SelectToken(mapeo.PropiedadOrigen);
                            objDestino.SelectToken(mapeo.PropiedadDestino).Replace(valor);
                        }
                    }
                    else
                    {
                        JToken valor = objOrigen.SelectToken(mapeo.PropiedadOrigen);
                        objDestino.SelectToken(mapeo.PropiedadDestino).Replace(valor);
                    }
                } 
            });

            return JsonConvert.DeserializeObject<R>(objDestino.ToString());
        }
    }
}
