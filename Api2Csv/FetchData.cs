using System;
using System.Configuration;
using System.IO;
using System.Net;


namespace Api2Csv
{
    public static class FetchData
    {
        public static string ApiConnect(string requestId)
        {
            try
            {
                string apiAuthHeader = ConfigurationManager.AppSettings["apiAuthHeader"];
                string apiBase = ConfigurationManager.AppSettings["apiBase"];
                string apiUrl = apiBase + requestId;
                Console.WriteLine(apiBase);
                Console.WriteLine(apiUrl);
                var httpRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
                httpRequest.Accept = "application/json";
                if (apiAuthHeader == String.Empty)
                {
                    Logger.Append("Warning: API authorization header is not used");
                }
                else
                {
                    httpRequest.Headers["Authorization"] = apiAuthHeader;
                }
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Logger.Append($"Failed to retrieve information from api, error: {e}");
                return null;
            }

        }
    }
}
