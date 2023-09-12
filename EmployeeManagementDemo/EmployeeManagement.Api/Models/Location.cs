using System;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Models
{
    public partial class Location
    {
        public Location()
        {
            Dive = new HashSet<Dive>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Locality { get; set; }
        public string Country { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lng { get; set; }

        public virtual ICollection<Dive> Dive { get; set; }
    }
}
