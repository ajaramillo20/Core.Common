using Core.Common.DataAccess.Helper;
using Core.Common.Model.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.DataAccess.Procesos.Errores
{
    public static class ObtenerErrorMicroservicioDAL
    {
        public class PA_CON_OBTENER_ERROR_MICROSERVICIO_RESULT
        {
            /// <summary>
            /// Id entidad
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// CodigoInterno
            /// </summary>
            public int CodigoInterno { get; set; }

            /// <summary>
            /// Modulo donde pertenece Ejemplo Core.Creditos
            /// </summary>
            public string Modulo { get; set; }

            /// <summary>
            /// Mensaje de error del código
            /// </summary>
            public string MensajeError { get; set; }
        }
        public static PA_CON_OBTENER_ERROR_MICROSERVICIO_RESULT Execute(int codigoInternorespuesta)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(ProcedimientoAlmacenado.PA_CON_OBTENER_ERROR_MICROSERVICIO.PARAM_CODIGO_RESPUESTA_INTERNO, codigoInternorespuesta, System.Data.DbType.Int32);

            DBConnectionHelper databaseTemplate =
                new DBConnectionHelper(EnumDBConnection.SqlConnection, DBConnectionString.BD_CONFIGURACIONES_DEV);

            var mensajeErrorInterno = databaseTemplate.ObtenerListaDatos<PA_CON_OBTENER_ERROR_MICROSERVICIO_RESULT>(
                ProcedimientoAlmacenado.PA_CON_OBTENER_ERROR_MICROSERVICIO.PA_NOMBRE,
                parametros);

            return mensajeErrorInterno.First();
        }
    }
}
