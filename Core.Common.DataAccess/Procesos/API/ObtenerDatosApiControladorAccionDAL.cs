using Core.Common.DataAccess.Helper;
using Core.Common.Model.Configuracion.API;
using Core.Common.Model.General;
using Dapper;

namespace Core.Common.DataAccess.Procesos.API
{
    public static class ObtenerDatosApiControladorAccionDAL
    {
        
        internal class PA_API_OBTENER_DATOS_ENDPOINT_Result
        {
            public PA_API_OBTENER_DATOS_ENDPOINT_Result() { }

            public string NombreAPIRest { get; set; }
            public string NombreControlador { get; set; }
            public string NombreAccion { get; set; }
            public string NombreObjetoRespuesta { get; set; }
            public string PropiedadOrigen { get; set; }
            public string PropiedadDestino { get; set; }
        }


        public static APIRest Execute(string nombreAccion) {

            List<PA_API_OBTENER_DATOS_ENDPOINT_Result> resultadoBD;
            APIRest resultAPI = new();
            
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(ProcedimientoAlmacenado.PA_API_OBTENER_DATOS_ENDPOINT.PARAM_NOMBRE_ACCION, nombreAccion, System.Data.DbType.String);

            DBConnectionHelper databaseTemplate = 
                new DBConnectionHelper(EnumDBConnection.SqlConnection, DBConnectionString.BD_CONFIGURACIONES);
           
            resultadoBD = databaseTemplate.ObtenerListaDatos<PA_API_OBTENER_DATOS_ENDPOINT_Result>(
                ProcedimientoAlmacenado.PA_API_OBTENER_DATOS_ENDPOINT.PA_NOMBRE, 
                parametros);

            var datosApi = resultadoBD.FirstOrDefault();
            if (datosApi != null)
            {
                resultAPI.NombreAPIRest = datosApi.NombreAPIRest;
                resultAPI.NombreControlador = datosApi.NombreControlador;
                resultAPI.NombreAccion = datosApi.NombreAccion;
                foreach (var item in resultadoBD)
                {
                    resultAPI.ObjetoRespuesta.ListaPropiedades.Add(new Propiedades()
                    {
                        PropiedadOrigen = item.PropiedadOrigen,
                        PropiedadDestino = item.PropiedadDestino
                    });
                }
            }
            return resultAPI;
        }

    }



}
