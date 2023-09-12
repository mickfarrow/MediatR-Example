using EmployeeManagementLibrary.Models;
using MediatR;

namespace EmployeeManagementLibrary.Queries
{
    public record GetEmployeeListRequest() : IRequest<List<Employee>>;
}
