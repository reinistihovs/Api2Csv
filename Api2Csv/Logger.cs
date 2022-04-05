using System;
using System.Configuration;
using System.IO;


namespace Api2Csv
{
    public static class Logger
    {
        public static void Append(string logMessage)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                try
                {
                    writer.WriteLine($"{DateTime.Now} : {logMessage}");
                }
                catch (DirectoryNotFoundException e)
                {
                    throw new Exception($"Directory {logPath} not found", e);
                }
                catch (UnauthorizedAccessException e)
                {
                    throw new Exception($"Could not access the directory {logPath}, permission denied", e);
                }
                catch (IOException e)
                {
                    throw new Exception("Error during file write", e);
                }
                catch (Exception e)
                {
                    throw new Exception("Error Occurred", e);
                }
            }

        }

    }
}
