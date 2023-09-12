using EmployeeManagement.Api.Entities;
using EmployeeManagement.Api.Models;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}