using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;

namespace Api2Csv
{
    public static class MakeCsv
    {
        public static void generate(string jsonContent)
        {


            //used NewtonSoft NuGet, its free for commercial use: https://www.newtonsoft.com/json
            try
            {
                string csvPath = ConfigurationManager.AppSettings["csvPath"];
                XmlNode xml = JsonConvert.DeserializeXmlNode("{records:{record:" + jsonContent + "}}");
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(xml.InnerXml);
                XmlReader xmlReader = new XmlNodeReader(xml);
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(xmlReader);
                var dataTable = dataSet.Tables[0];
                var rows = new List<string>();
                string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName).
                                                  ToArray();
                var header = string.Join(",", columnNames);

                // Skip adding header, if file already exists.
                if (!File.Exists(csvPath))
                {
                    rows.Add(header);
                }
                var valueRows = dataTable.AsEnumerable()
                                   .Select(row => string.Join(",", row.ItemArray));
                rows.AddRange(valueRows);
                try
                {
                    File.AppendAllLines(csvPath, rows);
                }
                catch (DirectoryNotFoundException e)
                {
                    Logger.Append($"Directory {csvPath} not found, error: {e}");
                    throw new Exception($"Directory {csvPath} not found", e);
                }
                catch (UnauthorizedAccessException e)
                {
                    Logger.Append($"Could not access the directory {csvPath}, permission denied, error: {e}");
                    throw new Exception($"Could not access the directory {csvPath}, permission denied", e);
                }
                catch (IOException e)
                {
                    Logger.Append($"Error during csv file write, error: {e}");
                    throw new Exception("Error during csv file write", e);
                }
                catch (Exception e)
                {
                    Logger.Append($"Error occurred, cant create csv file, error: {e}");
                    throw new Exception("Error occurred, cant create csv file", e);
                }
            }
            catch (Exception e)
            {
                Logger.Append($"Failed to append csv file, error: {e}");
            }
        }
    }
}
