using Core.Common.Util.Modelos.General;
using Core.Common.Util.Modelos.Respuesta;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Util.Helper
{
    public static class MapHelper
    {

        public static R MapeoDinamicoRespuesta<T, R>(T transaccion, R respuesta)
        {

            List<PropiedadObjetoRespuesta> propiedades = new List<PropiedadObjetoRespuesta>()
            {
                new PropiedadObjetoRespuesta() {
                    PropiedadOrigen = "DatoTrx001",
                    PropiedadDestino = "DatoResponse001"
                },
                new PropiedadObjetoRespuesta() {
                    PropiedadOrigen = "DatoTrx002",
                    PropiedadDestino = "DatoResponse002"
                },
                new PropiedadObjetoRespuesta() {
                    PropiedadOrigen = "DatoTrx004",
                    PropiedadDestino = "DatoResponse003"
                },
            };

            return MapeoDinamicoPropiedades(transaccion, respuesta, propiedades);
        }

        private static R MapeoDinamicoPropiedades<T, R>(T transaccion, R respuesta, List<PropiedadObjetoRespuesta> propiedades) {


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
                        if (origen.Type.ToString().Equals(MapType.Array.ToString(), StringComparison.CurrentCulture) &&
                            destino.Type.ToString().Equals(MapType.Array.ToString(), StringComparison.CurrentCulture))
                        {
                            JToken valor = objOrigen.SelectToken(mapeo.PropiedadOrigen).FirstOrDefault();
                            objDestino.SelectToken(mapeo.PropiedadDestino).Replace(valor);
                        }
                        else if (origen.Type.ToString().Equals(MapType.Object.ToString(), StringComparison.CurrentCulture) &&
                            destino.Type.ToString().Equals(MapType.Object.ToString(), StringComparison.CurrentCulture))
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
