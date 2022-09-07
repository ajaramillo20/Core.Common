using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Model.General
{
    public static class ConstantesRest 
    {
        public const string GUID_EMPTY = "00000000-0000-0000-0000-000000000000";
    }

    public static class ConstantesGenerales
    {
        public const string EMPRESA = "ORIGINARSA";
        public const string RUC = "171827635172361";
    }

    public static class ConstantesCRUD
    {
        public const string ACCION_CRUD_INSERTAR = "Insert";
        public const string ACCION_CRUD_EDITAR = "Edit";
        public const string ACCION_CRUD_ELIMINAR = "Delete";
    }

    public static class ConstantesCatalogo
    {      
        /// <summary>
        /// 
        /// </summary>
        public const string OPERADORES = "OPERADORES";
        public const string PARAMETROS_EVALUACION = "PARAMETROS EVALUACION";

        // ITEMS DE CATALOSO

        public const int ID_DEFAULT = 0;
        public const string CODIGO_DEFAULT = "DEF-000";
        public const string VALOR_DEFAULT = "0";
        public const string NOMBRE_DEFAULT = "--- SELECCIONE ---";

        // VARIABLES DE ACCESO

        public const string DATA_VALUE_FIELD = "Valor";
        public const string DATA_VALUE_TEXT = "Nombre";
    }

}
