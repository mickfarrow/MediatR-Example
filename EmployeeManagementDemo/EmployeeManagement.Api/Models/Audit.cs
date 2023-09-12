using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class Audit
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public string OldVal { get; set; }
        public string NewVal { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
    }
}
