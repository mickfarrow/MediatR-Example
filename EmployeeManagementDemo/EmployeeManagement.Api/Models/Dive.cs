using System;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Models
{
    public partial class Dive
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int DiverId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeIn { get; set; }
        public short Minutes { get; set; }
        public TimeSpan? TimeOut { get; set; }
        public string Visibility { get; set; }
        public decimal? MaxDepthFt { get; set; }
        public decimal? MaxDepthM { get; set; }
        public decimal? AvgDepthFt { get; set; }
        public decimal? AvgDepthM { get; set; }
        public bool? SafetyStop { get; set; }
        public int? WeightLb { get; set; }
        public decimal? TemperatureF { get; set; }
        public int? StartPg { get; set; }
        public int? EndPg { get; set; }
        public string Notes { get; set; }

        public virtual Diver Diver { get; set; }
        public virtual Location Location { get; set; }
    }
}
