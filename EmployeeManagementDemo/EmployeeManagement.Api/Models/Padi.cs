using System;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Models
{
    public partial class Padi
    {
        public Padi()
        {
            Diver = new HashSet<Diver>();
        }

        public int Id { get; set; }
        public string Level { get; set; }

        public virtual ICollection<Diver> Diver { get; set; }
    }
}
