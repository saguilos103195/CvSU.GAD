﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CVSUGADEntities : DbContext
    {
        public CVSUGADEntities()
            : base("name=CVSUGADEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Disaggregation> Disaggregations { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<Seminar> Seminars { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
