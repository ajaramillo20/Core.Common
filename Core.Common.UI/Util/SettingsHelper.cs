using Microsoft.Extensions.Configuration;

namespace Core.Common.Util.Helper.API
{
    public static class SettingsHelper
    {

        private static IConfiguration _configuration;

        public static void ObtenerJsonAppSetings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string ObtenerConnectionString(string nombreBaseDatos)
        {
            return _configuration.GetConnectionString(nombreBaseDatos);        
        }

        public static string ObtenerSettigsKey(string key)
        {
            try
            {
                string[] configs = key.Split('.');

                IConfigurationSection cadenaConfig = _configuration.GetSection(configs.First());
                for (int i = 1; i < configs.Length; i++)
                {
                    cadenaConfig = cadenaConfig.GetSection(configs[i]);
                }

                return cadenaConfig.Value;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

    }
}
