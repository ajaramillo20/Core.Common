using Core.Common.DataAccess.Helper;
using Core.Common.Model.Configuracion.Sistemas;
using Core.Common.Model.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.DataAccess.Procesos.VariablesSistema
{
    public static class ObtenerVariablesSistemaDAL
    {

        internal class PA_OBTENER_VARIABLE_SISTEMA_Result
        {
            public PA_OBTENER_VARIABLE_SISTEMA_Result() { }

            public int Id { get; set; }
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Valor { get; set; }
            public string Descripcion { get; set; }
            public string Grupo { get; set; }
        }


        public static VariableSistema Execute(string nombreAccion)
        {

            List<PA_OBTENER_VARIABLE_SISTEMA_Result> resultadoBD;
            VariableSistema resultVariableSistema = new();

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(ProcedimientoAlmacenado.PA_CON_OBTENER_VARIABLE_SISTEMA.PARAM_NOMBRE_ACCION, nombreAccion, System.Data.DbType.String);

            DBConnectionHelper databaseTemplate =
                new DBConnectionHelper(EnumDBConnection.SqlConnection, DBConnectionString.BD_CONFIGURACIONES);

            resultadoBD = databaseTemplate.ObtenerListaDatos<PA_OBTENER_VARIABLE_SISTEMA_Result>(
                ProcedimientoAlmacenado.PA_CON_OBTENER_VARIABLE_SISTEMA.PA_NOMBRE,
                parametros);

            var variableSistema = resultadoBD.FirstOrDefault();
            if (variableSistema != null)
            {
                resultVariableSistema.Id = variableSistema.Id;
                resultVariableSistema.Codigo = variableSistema.Codigo;
                resultVariableSistema.Nombre = variableSistema.Nombre;
                resultVariableSistema.Valor = variableSistema.Valor;
                resultVariableSistema.Descripcion = variableSistema.Descripcion;
                resultVariableSistema.Grupo = variableSistema.Grupo;
            }
            return resultVariableSistema;
        }


       

    }
}
