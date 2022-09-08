using Core.Common.Model.General;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Core.Common.DataAccess.Helper
{
    /// <summary>
    /// Clase encargada de la gestion para la conexion y acceso a bases de datos mediante Dapper.
    /// </summary>
    public class DBConnectionHelper : ControllerBase
    {        
        /// <summary>
        /// Variable de conexion para inyeccion de conexion a base de datos
        /// </summary>
        private readonly IDbConnection _connection;

        /// <summary>
        /// Contructor de conexion a base de datos (Usa una ConnectionString completa)
        /// </summary>
        /// <param name="enumConnectionn">Tipo de coneccion que se desea realizar</param>
        /// <param name="connectionString">Cadenade conexion completa</param>
        public DBConnectionHelper(EnumDBConnection enumConnectionn, string connectionString)
        {
            switch (enumConnectionn)
            {
                case EnumDBConnection.SqlConnection:
                    _connection = new SqlConnection(connectionString);
                    break;

                case EnumDBConnection.MySqlConnection:
                    _connection = new MySqlConnection(connectionString);
                    break;
                default:
                    _connection = new SqlConnection(connectionString);
                    break;
            }
        }

        public int Ejecutar<DBModel>(string procedimientoAlmacenado, DynamicParameters parametros)
        {
            try
            {
                using (_connection)
                {
                    _connection.Open();
                    using (IDbTransaction transaction = _connection.BeginTransaction())
                    {
                        try
                        {
                            _connection.Execute(procedimientoAlmacenado, param: parametros, transaction, commandType: CommandType.StoredProcedure);
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return parametros.Get<int>(ProcedimientoAlmacenado.PARAM_CODIGO_RETORNO);
                        }
                    }
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                return parametros.Get<int>(ProcedimientoAlmacenado.PARAM_CODIGO_RETORNO);
            }
            return parametros.Get<int>(ProcedimientoAlmacenado.PARAM_CODIGO_RETORNO);
        }


        /// <summary>
        /// Metodo para recuperar informacion mediante un procedimiento almacenado sin parametros.
        /// </summary>
        /// <typeparam name="DBModel">Tipo de objeto de la base de datos</typeparam>
        /// <param name="procedimientoAlmacenado">Nombre del procedimiento almacenado</param>
        /// <returns>Lista con datos de tipo DBModel (1 ResultSet)</returns>
        public List<DBModel> ObtenerListaDatos<DBModel>(string procedimientoAlmacenado)
        {
            List<DBModel> dbModelResult;
            using (_connection)
            {
                dbModelResult = _connection.Query<DBModel>(procedimientoAlmacenado, commandType: CommandType.StoredProcedure).ToList();
            }
            return dbModelResult;
        }

        /// <summary>
        /// Metodo para recuperar informacion mediante un procedimiento almacenado con parametros.
        /// </summary>
        /// <typeparam name="DBModel">Tipo de objeto de la base de datos</typeparam>
        /// <param name="procedimientoAlmacenado">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Lista de parametros del procedimiento almacenado</param>
        /// <returns></returns>
        public List<DBModel> ObtenerListaDatos<DBModel>(string procedimientoAlmacenado, DynamicParameters parametros)
        {
            List<DBModel> dbModelResult;
            using (_connection)
            {
                dbModelResult = _connection.Query<DBModel>(procedimientoAlmacenado, parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return dbModelResult;
        }

        /// <summary>
        /// Metodo para insertar datos de manera transaccional 
        /// </summary>
        /// <param name="procedimientoAlmacenado">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Lista de parametros del procedimiento almacenado</param>
        /// <returns>Codigo de respuesta enviado por la ejecucion del procedimiento almacenado (@CodigoRetorno)</returns>
        public int InsertarDatos(string procedimientoAlmacenado, DynamicParameters parametros)
        {
            try
            {
                using (_connection)
                {
                    _connection.Open();
                    using (IDbTransaction transaction = _connection.BeginTransaction())
                    {
                        try
                        {
                            _connection.Execute(procedimientoAlmacenado, param: parametros, transaction, commandType: CommandType.StoredProcedure);
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return parametros.Get<int>(ProcedimientoAlmacenado.PARAM_CODIGO_RETORNO);
                        }
                    }
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                return parametros.Get<int>(ProcedimientoAlmacenado.PARAM_CODIGO_RETORNO);
            }
            return parametros.Get<int>(ProcedimientoAlmacenado.PARAM_CODIGO_RETORNO);
        }

        public ArrayList ObtenerQueryMultiple<DBModel1, DBModel2>(string storedProcedureName, string nombreBase, DynamicParameters parameter)
        {
            return new ArrayList() { new List<DBModel1>(), new List<DBModel2>() };
        }

        public ArrayList ObtenerQueryMultiple<DBModel1, DBModel2, DBModel3>(string storedProcedureName, string nombreBase, DynamicParameters parameter)
        {
            return new ArrayList() { new List<DBModel1>(), new List<DBModel2>() };
        }

        public ArrayList ObtenerQueryMultiple<DBModel1, DBModel2, DBModel3, DBModel4>(string storedProcedureName, string nombreBase, DynamicParameters parameter)
        {
            return new ArrayList() { new List<DBModel1>(), new List<DBModel2>() };
        }

    }
}
