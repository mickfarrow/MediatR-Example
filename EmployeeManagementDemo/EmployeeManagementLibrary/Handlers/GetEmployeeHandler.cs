using EmployeeManagementLibrary.Data;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.Queries;
using MediatR;

namespace EmployeeManagementLibrary.Handlers
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeRequest, Employee>
    {
        private readonly IDataAccess _dataAccess;
        public GetEmployeeHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<Employee> Handle(GetEmployeeRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetEmployee(request.id));
        }
    }
}
