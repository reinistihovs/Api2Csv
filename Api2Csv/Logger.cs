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
                catch (DirectoryNotFoundException ex)
                {
                    throw new Exception($"Directory {logPath} not found", ex);
                }
                catch (UnauthorizedAccessException ex)
                {
                    throw new Exception($"Could not access the directory {logPath}, permission denied", ex);
                }
                catch (IOException ex)
                {
                    throw new Exception("Error during file write", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Occurred", ex);
                }
            }

        }

    }
}
