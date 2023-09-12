using EmployeeManagement.Api.Entities;
using EmployeeManagement.Api.Models;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Services
{
    public interface IDivesService
    {
        IEnumerable<Dive> GetDives();
    }
}