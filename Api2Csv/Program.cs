namespace Api2Csv
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Logger.Append($"App launched without arguments, nothing to do!");
            }
            else
            {
                //Splits comma separated arguments to an array and loops.
                foreach (string arg in args[0].Split(','))

                {
                    Logger.Append($"Fetching data for object: {arg}");
                    //Get json file from API server
                    string jsonString = FetchData.ApiConnect(arg);
                    //Generate CSV file, append if file exists
                    MakeCsv.generate(jsonString);
                }
            }
        }
    }
}
