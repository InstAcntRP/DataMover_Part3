using DataMover.Data;
using DataMover.Model;
using Microsoft.EntityFrameworkCore;

namespace DataMover.Services{

    public class DataIngestionService:IDataIngestionService
    {
        private EmployeeDataContext _employeeDataContext;

        public DataIngestionService(EmployeeDataContext employeeDataContext)
        {
            _employeeDataContext = employeeDataContext;
        }
        public async Task<int> IngestData(List<string> empDataList)
        {
            /*
            for(int index = 0; index< empDataList.Count();index++ )
            {
                    EmployeeDataModel employeeDataModel = new EmployeeDataModel();
                    Console.WriteLine($" index  - {index}, Data - {empDataList[index]}");
            }*/
            int resultCount = -1;
            for(int index = 0; index< empDataList.Count();index++ )
            {
                List<string> splittedData = new List<string>();
                splittedData = empDataList[index].Split(",").ToList();
                EmployeeDatum employee = new EmployeeDatum();
                employee.EmployeeFirstName =  splittedData[0];
                employee.EmployeeLastName = splittedData[1];
                employee.Department = splittedData[2];;
                employee.Role = splittedData[3];
                _employeeDataContext.Entry(employee).State = EntityState.Added;
            }
            resultCount =await _employeeDataContext.SaveChangesAsync();
            Console.WriteLine($"resultCount - {resultCount}");
            return resultCount;
        }
    }
}
