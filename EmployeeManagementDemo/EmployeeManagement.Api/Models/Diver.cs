using System;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Models
{
    public partial class Diver
    {
        public Diver()
        {
            Dives = new HashSet<Dive>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Padinumber { get; set; }
        public int? Padilevel { get; set; }

        public virtual Padi PadilevelNavigation { get; set; }
        public virtual ICollection<Dive> Dives { get; set; }
    }
}
