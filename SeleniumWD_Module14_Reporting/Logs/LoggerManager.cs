using log4net.Config;
using System;
using System.IO;

namespace SeleniumWebDriver.Logs
{
    public static class LoggerManager
    {
        static LoggerManager()
        {
           XmlConfigurator.Configure(new FileInfo("Log.config"));
        }

        public static Logger GetLogger(Type type)
        {
            return new Logger(type);
        }
    }
}
