namespace DataMover.Services
{
    public interface IDataIngestionService
    {
       Task<int> IngestData(List<string> empDataList);
    }
}