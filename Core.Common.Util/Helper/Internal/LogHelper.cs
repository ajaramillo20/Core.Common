using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Tls;
using Serilog;
using Serilog.Core;
using System.Configuration;

namespace Core.Common.Util.Helper.Internal
{
    public static class LogHelper
    {
        private static Logger Logger;
        public static void ConfigurarServicio(WebApplicationBuilder builder)
        {
            Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(Logger);
        }

        public static void Write(string message)
        {
            Logger.Information(message);
        }
    }
}
