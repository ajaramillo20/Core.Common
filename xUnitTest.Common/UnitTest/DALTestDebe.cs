
using Core.Common.DataAccess.Helper;
using Core.Common.DataAccess.Procesos.VariablesSistema;
using Core.Common.Model.General;
using Dapper;
using System.Data;

namespace xUnitTest.Common.UnitTest
{
    public class DALTestDebe
    {
        [Fact]
        public void ObtenerVariableSistema()
        {
            var result = ObtenerVariablesSistemaDAL.Execute("VAS_001");
        }

        [Fact]
        public void InsertarConcesionario()
        {
            var cs = "Data Source=10.0.0.46\\BDAPPDEV;Initial Catalog=BD_SEGURIDADES;User ID=developer;password=Developer.2022";

            DBConnectionHelper coneccion = new DBConnectionHelper(EnumDBConnection.SqlConnection, cs);
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Nombre", "Carlos", System.Data.DbType.String);
            dynamicParameters.Add("@Correo", "csilva@originarsa.com", System.Data.DbType.String);
            dynamicParameters.Add("@Clave", "12345", System.Data.DbType.String);
            dynamicParameters.Add("@Identificacion", "17163082186", System.Data.DbType.String);
            dynamicParameters.Add("@CodigoRetorno", System.Data.DbType.Int32, direction: ParameterDirection.ReturnValue);

            var result = coneccion.InsertarDatos("PA_CON_AGREGAR_CONCESIONARIO", dynamicParameters);
        }
    }
}
