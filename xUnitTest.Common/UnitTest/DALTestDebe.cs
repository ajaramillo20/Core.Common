
using Core.Common.DataAccess.Helper;
using Core.Common.DataAccess.Procesos.VariablesSistema;

namespace xUnitTest.Common.UnitTest
{
    public class DALTestDebe
    {
        [Fact]
        public void ObtenerVariableSistema()
        {
            var result = ObtenerVariablesSistemaDAL.Execute("VAS_001");
        }
    }
}
