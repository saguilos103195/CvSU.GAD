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
    
    public partial class Education
    {
        public int EducationID { get; set; }
        public int AccountID { get; set; }
        public string SchoolName { get; set; }
        public string Course { get; set; }
        public string EducationalLevel { get; set; }
        public System.DateTime DateFrom { get; set; }
        public System.DateTime DateTo { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
