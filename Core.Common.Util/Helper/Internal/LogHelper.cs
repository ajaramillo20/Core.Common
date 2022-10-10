using Core.Common.DataAccess.Procesos.Auditoria;
using Core.Common.Model.General;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Org.BouncyCastle.Tls;
using Serilog;
using Serilog.Core;
using System.Configuration;

namespace Core.Common.Util.Helper.Internal
{
    public static class LogHelper
    {
        private static Logger Logger;

        /// <summary>
        /// Metodo para configurar en cada endpoint
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigurarServicio(WebApplicationBuilder builder)
        {
            Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(Logger);
        }

        /// <summary>
        /// Metodo para escribir nuevo log por tipo de Log:
        /// Entrada, salida, error, adevertencia, debug
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fullNameSource"></param>
        /// <param name="tipoLog"></param>
        public static void EscribirLog(string accion, string objetoTrxJson, string fullNameSource, string credencialCodigo, TipoMensajeLog tipoLog)
        {
            try
            {
                var logServicio = new LogServicio
                {
                    Accion = accion,
                    Source = fullNameSource,
                    TipoMensaje = tipoLog,
                    Fecha = DateTime.Now,
                    CodigoCredencial = credencialCodigo,
                    ObjetoTrxJson = objetoTrxJson
                };

                AgregarLogServicioDAL.Execute(logServicio);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }
    }
}
