namespace NDPSo.Utils
{
    public class ConfigManager
    {
        private static TramTronConfig _TramTronConfig = new TramTronConfig();
        private static ServiceConfig _ServiceConfig = new ServiceConfig();

        public static TramTronConfig TramTronConfig => ConfigManager._TramTronConfig;

        public static ServiceConfig ServiceConfig => ConfigManager._ServiceConfig;
    }
}