﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HMSEntities : DbContext
    {
        public HMSEntities()
            : base("name=HMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Lab_Report> Lab_Report { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Report_Type> Report_Type { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
    }
}