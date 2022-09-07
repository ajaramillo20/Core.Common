using Core.Common.DataAccess.Procesos.VariablesSistema;
using Core.Common.Model.Configuracion.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Util.Helper.Datos
{
    /// <summary>
    /// Helper encargado de recueprar la informacion de variables sistema
    /// </summary>
    public static class VariablesSistemaHelper
    {
        public static string ObtenerValor(string codigoVariable)
        {
            return ObtenerVariablesSistemaDAL.Execute(codigoVariable).Valor; 
        }

        public static VariableSistema ObtenerDatosCompletos(string codigoVariable)
        {
            try
            {
                return ObtenerVariablesSistemaDAL.Execute(codigoVariable);
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
