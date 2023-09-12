using EmployeeManagementLibrary.Models;
using MediatR;

namespace EmployeeManagementLibrary.Queries
{
    public record GetEmployeeRequest(int id) : IRequest<Employee>;
}