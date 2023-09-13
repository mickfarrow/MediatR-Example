using EmployeeManagementLibrary.Models;

namespace EmployeeManagementLibrary.Data
{
    public class DataAccess : IDataAccess
    {
        private readonly String _connectionString = "Data Source=\"localhost, 1402\";Initial Catalog=HR;User ID=sa;Password=MickFarrow23!!;TrustServerCertificate=true";
        public List<Employee> GetEmployees()
        {
            var context = new EmployeeContext(_connectionString);

            var employees = context.Employee.ToList();
            return employees;
        }
        public Employee GetEmployee(int id)
        {
            var list = GetEmployees();
            return list.Single(x => x.Id == id);
        }
    }
}
