using Core.Common.Model.Configuracion.APIExterna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Util.Helper.API
{
    public static class NotificacionCreditos
    {
        public static void SendRequest(RequestApiExterna peticionData)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    if (peticionData.QueryParams != null && peticionData.QueryParams.Count > 0)
                    {
                        string queryParams = (peticionData.QueryParams == null || peticionData.QueryParams.Count == 0) ? "" : "?";
                        foreach (var item in peticionData.QueryParams)
                        {
                            queryParams = $"{queryParams}{item.Nombre}={item.Valor}&";
                        }
                        peticionData.Url = $"{peticionData.Url}{queryParams}";
                    }
                    using (var request = new HttpRequestMessage(new HttpMethod(peticionData.Metodo), peticionData.Url))
                    {

                        foreach (var para in peticionData.Headers)
                        {
                            request.Headers.TryAddWithoutValidation(para.Nombre, para.Valor);
                        }

                        request.Content = new StringContent(peticionData.Content);
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(peticionData.ContentType);

                        var response = httpClient.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}
