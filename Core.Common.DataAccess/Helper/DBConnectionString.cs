using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.DataAccess.Helper
{
    public static class DBConnectionString
    {

        public const string BD_CONFIGURACIONES_DEV = "Data Source=10.0.0.46\\BDAPPDEV;Initial Catalog=BD_CONFIGURACIONES;User ID=sa;password=Py#CgSE6h9";
        public const string BD_CONFIGURACIONES_PROD = "Data Source=SRVWINBDWH\\ORIGINARSA;Initial Catalog=BD_CONFIGURACIONES;User ID=dpaz;password=P@ssw0rd.01";

    }
}
