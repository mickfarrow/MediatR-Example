using System;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Models
{
    public partial class DiveLog
    {
        public int DiveNumber { get; set; }
        public string Day { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Locality { get; set; }
        public string Visibility { get; set; }
        public int DepthFt { get; set; }
        public double DepthM { get; set; }
        public string AvgDepthFt { get; set; }
        public double AvgDepthM { get; set; }
        public string SafetyStop { get; set; }
        public string Equipment { get; set; }
        public int WeightLb { get; set; }
        public int TempF { get; set; }
        public double TempC { get; set; }
        public int StartPg { get; set; }
        public int EndPg { get; set; }
        public double PsiperMin { get; set; }
        public TimeSpan TimeIn { get; set; }
        public TimeSpan BottomToDate { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan Cumulative { get; set; }
        public TimeSpan TimeOut { get; set; }
        public string SurfaceTime { get; set; }
        public string Weather { get; set; }
        public string Observations { get; set; }
        public string DivedWith { get; set; }
    }
}
