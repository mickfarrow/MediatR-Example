using EmployeeManagementLibrary.Models;

namespace EmployeeManagementLibrary.Data
{
    public interface IDataAccess
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
    }
}
