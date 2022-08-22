namespace Core.Common.Model.General
{
    public enum Error {
        OperacionExitosa = 10000,
    }

    public enum ParametroOfertaCartera
    {
        MontoDeCredito,

        PlazoMaximo,

        TipoDeCredito,

        TipoDeAuto,
    }


    public enum EstadoProceso
    {
        OK = 1,
        ERROR = 2,
        WARNING = 3
    }

    public enum EnumTipoRespuesta
    {
        APR_CON_REC,
        APR_SIN_REC,
        NEG,
        PEN,
        NO_OFERTABLE,
        SIN_RESPUESTA,
    }

    public enum TipoProceso
    {
        CONSULTAR_OFERTA,
        GENERAR_OFERTA,
        CARGAR_RESPUESTA,
        CONSULTAR_VENTA,
        GENERAR_VENTA
    }


}
