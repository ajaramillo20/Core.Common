using Core.Common.DataAccess.Helper;
using Core.Common.Model.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Common.DataAccess.Procesos.Errores.ObtenerErrorMicroservicioDAL;
using static Dapper.SqlMapper;

namespace Core.Common.DataAccess.Procesos.Auditoria
{
    public static class AgregarLogServicioDAL
    {
        public static void Execute(LogServicio log)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PARAM_LOG_ACCION, log.Accion, System.Data.DbType.String);
            parametros.Add(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PARAM_LOG_SOURCE, log.Source, System.Data.DbType.String);
            parametros.Add(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PARAM_LOG_TIPO_MENSAJE, log.TipoMensaje, System.Data.DbType.String);
            parametros.Add(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PARAM_LOG_FECHA, log.Fecha, System.Data.DbType.DateTime);
            parametros.Add(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PARAM_CREDENCIAL_CODIGO, log.CodigoCredencial, System.Data.DbType.String);
            parametros.Add(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PARAM_OBJETO_JSON, log.ObjetoTrxJson, System.Data.DbType.String);
            

            parametros.Add(ProcedimientoAlmacenado.PARAM_CODIGO_RETORNO, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            DBConnectionHelper databaseTemplate =
                new DBConnectionHelper(EnumDBConnection.SqlConnection, DBConnectionString.BD_CONFIGURACIONES);

            databaseTemplate.Ejecutar<int>(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PA_NOMBRE, parametros);
        }
        public static void Execute(List<LogServicio> logs)
        {
            foreach (var log in logs)
            {
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PARAM_LOG_ACCION, log.Accion, System.Data.DbType.String);
                parametros.Add(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PARAM_LOG_SOURCE, log.Source, System.Data.DbType.String);
                parametros.Add(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PARAM_LOG_TIPO_MENSAJE, log.TipoMensaje, System.Data.DbType.String);
                parametros.Add(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PARAM_LOG_FECHA, log.Fecha, System.Data.DbType.DateTime);
                parametros.Add(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PARAM_CREDENCIAL_CODIGO, log.CodigoCredencial, System.Data.DbType.String);
                parametros.Add(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PARAM_OBJETO_JSON, log.ObjetoTrxJson, System.Data.DbType.String);


                DBConnectionHelper databaseTemplate =
                    new DBConnectionHelper(EnumDBConnection.SqlConnection, DBConnectionString.BD_CONFIGURACIONES);

                databaseTemplate.Ejecutar<int>(ProcedimientoAlmacenado.PA_CON_AGREGAR_LOG_MICROSERVICIO.PA_NOMBRE, parametros);
            }
        }
    }
}
