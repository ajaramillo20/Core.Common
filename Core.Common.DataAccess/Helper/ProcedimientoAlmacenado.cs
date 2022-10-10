using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.DataAccess.Helper
{
    public static class ProcedimientoAlmacenado
    {
        public const string PARAM_CODIGO_RETORNO = "@CodigoRetorno";

        public static class PA_API_OBTENER_DATOS_ENDPOINT
        {
            public const string PA_NOMBRE = "PA_API_OBTENER_DATOS_ENDPOINT";
            public const string PARAM_NOMBRE_ACCION = "@NombreAccion";
        }

        public static class PA_CON_OBTENER_VARIABLE_SISTEMA
        {
            public const string PA_NOMBRE = "PA_CON_OBTENER_VARIABLE_SISTEMA";
            public const string PARAM_NOMBRE_ACCION = "@CodigoVariable";
        }

        public static class PA_CON_OBTENER_ERROR_MICROSERVICIO
        {
            public const string PA_NOMBRE = "PA_CON_OBTENER_ERROR_MICROSERVICIO";
            public const string PARAM_CODIGO_RESPUESTA_INTERNO ="@CodigoInternoRespuesta";
        }

        public static class PA_CON_AGREGAR_LOG_MICROSERVICIO
        {
            public const string PA_NOMBRE = "PA_CON_AGREGAR_LOG_MICROSERVICIO";
            public const string PARAM_LOG_ACCION = "@Accion";
            public const string PARAM_LOG_SOURCE = "@Source";
            public const string PARAM_LOG_TIPO_MENSAJE = "@TipoMensaje";
            public const string PARAM_LOG_FECHA = "@Fecha";
            public const string PARAM_CREDENCIAL_CODIGO = "@CredencialCodigo";
            public const string PARAM_OBJETO_JSON = "@ObjetoTrxJson";
        }

    }
     
}
