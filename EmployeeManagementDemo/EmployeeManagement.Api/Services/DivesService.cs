using EmployeeManagement.Api.Helpers;
using EmployeeManagement.Api.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Api.Services
{
    public class DivesService : IDivesService
    {
        private readonly AppSettings _appSettings;

        public DivesService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public IEnumerable<Dive> GetDives()
        {
            DiveLoggerContext context = new DiveLoggerContext(_appSettings.ConnectionString);

            var dives = context.Dive.ToList();
            return dives;
        }
    }
}
