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
                var lines = new List<string>();
                string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName).
                                                  ToArray();
                var header = string.Join(",", columnNames);
                if (!File.Exists(csvPath))
                {
                    lines.Add(header);
                }
                var valueLines = dataTable.AsEnumerable()
                                   .Select(row => string.Join(",", row.ItemArray));
                lines.AddRange(valueLines);
                try
                {
                    File.AppendAllLines(csvPath, lines);
                }
                catch (DirectoryNotFoundException e)
                {
                    Logger.Append($"Failed to append csv file, error: {e}");
                    throw new Exception($"Directory {csvPath} not found", e);
                }
                catch (UnauthorizedAccessException e)
                {
                    Logger.Append($"Failed to append csv file, error: {e}");
                    throw new Exception($"Could not access the directory {csvPath}, permission denied", e);
                }
                catch (IOException e)
                {
                    Logger.Append($"Failed to append csv file, error: {e}");
                    throw new Exception("Error during csv file write", e);
                }
                catch (Exception e)
                {
                    Logger.Append($"Failed to append csv file, error: {e}");
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
