using System;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;


namespace Api2Csv
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string arg in args[0].Split(','))
            {
                Logger.Append(arg);
                string jsonString = FetchData.ApiConnect(arg);
                MakeCsv.generate(jsonString);
            }
        }
    }
}
