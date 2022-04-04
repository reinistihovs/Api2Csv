using System;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;


namespace ApiToCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string arg in args[0].Split(','))
            {
                Console.WriteLine(arg);
                Logger.Append(arg);
            }

            string sAttr;
            sAttr = ConfigurationManager.AppSettings.Get("LogPath");
            Console.WriteLine("The value of Key0 is " + sAttr);

            // Read all the keys from the config file
            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;

            foreach (string s in sAll.AllKeys)
                Console.WriteLine("Key: " + s + " Value: " + sAll.Get(s));
            Console.ReadLine();
        }
    }
}
