namespace Core.Common.Model.General
{

    public enum EnumDBConnection
    {
        SqlConnection,
        MySqlConnection,
    }

    public enum EnumError {
        OperacionExitosa = 10000,
    }

    public enum EnumErrorComponentesComunes
    {
        ErrorProcessTemplate = 12001,
    }

    public enum EnumEstadoProceso
    {
        OK = 1,
        ERROR = 2,
        WARNING = 3,
    }

    public enum EnumMapType
    {
        Array = 1,
        Object = 2,
    }


}
