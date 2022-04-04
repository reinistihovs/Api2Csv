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
                foreach (string arg in args[0].Split(','))

                {
                    Logger.Append($"Fetching data for object: {arg}");
                    string jsonString = FetchData.ApiConnect(arg);
                    MakeCsv.generate(jsonString);
                }
            }
        }
    }
}
