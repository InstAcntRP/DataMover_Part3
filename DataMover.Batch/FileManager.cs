using DataMover.Services;

namespace DataMover.Batch
{
    public class FileManager
    {
        IDataIngestionService _dataIngestionService;

        public FileManager(IDataIngestionService dataIngestionService)
        {
            _dataIngestionService = dataIngestionService;
        }
        public void ParseFileAndGetData(string fileName)
        {
            Console.WriteLine($"Parsing the file -{fileName}");
            List<string> empDataList = new List<string>();

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                while(streamReader.Peek()>-1)
                {
                    string? line = streamReader.ReadLine();
                    if(!string.IsNullOrEmpty(line))
                    {
                        Console.WriteLine($"Content from the file - {line}");
                        if(!line.Contains("Employee First Name",StringComparison.CurrentCultureIgnoreCase))
                        {
                            empDataList.Add(line);
                        }
                    }
                }
            }
            int rowAffected = -1;
            var task = Task.Run(async() => rowAffected = await _dataIngestionService.IngestData(empDataList));           
            Console.WriteLine("Calling method.waiting");
            System.Threading.Thread.Sleep(new TimeSpan(00,00,07));
            Console.WriteLine($"Ingestion complete, rowAffected- {rowAffected}");
            /*
            DataIngestionService dataIngestionService = new DataIngestionService();
            dataIngestionService.IngestData(empDataList) ;
            */
        }
    }
}