//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CvSU.GAD.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Disaggregation
    {
        public int DisaggregationID { get; set; }
        public int PositionID { get; set; }
        public int ProgramID { get; set; }
        public int MaleQuantity { get; set; }
        public int FemaleQuantity { get; set; }
        public string Semester { get; set; }
        public string SchoolYear { get; set; }
        public int AccountID { get; set; }
        public int DepartmentID { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Position Position { get; set; }
        public virtual Program Program { get; set; }
    }
}