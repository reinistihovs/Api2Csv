using System;
using System.Configuration;
using System.IO;


namespace ApiToCsv
{
    class Logger
    {
        //public StreamWriter w = File.AppendText(ConfigurationManager.AppSettings.Get("LogPath"));
        public static void Append(string logMessage)
        {

            //File.AppendText(ConfigurationManager.AppSettings.Get("LogPath")).WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} :{logMessage}");
            //ile.AppendText(ConfigurationManager.AppSettings.Get("LogPath")).WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} :{logMessage}");

        }

    }
}
