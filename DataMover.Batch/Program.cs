using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DataMover.Data;
using DataMover.Services;

namespace DataMover.Batch
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Hello, World!");
            string fileName = @"C:\temp\Visual Studio Code\DataMover\Employee Data.csv";
            IHostBuilder builder= Host.CreateDefaultBuilder();
            builder.ConfigureServices((context,services) =>
            {
                services.AddScoped<IDataIngestionService, DataIngestionService>();
                services.AddDbContext<EmployeeDataContext>();
                services.AddSingleton<FileManager>();
            });
            IHost host= builder.UseConsoleLifetime().Build();
            FileManager app = host.Services.GetRequiredService<FileManager>();
            app.ParseFileAndGetData(fileName);

            /*
            FileManager fileManager = new FileManager();
            fileManager.ParseFileAndGetData(fileName);
            */
        }
    }
}



