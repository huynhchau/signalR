﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BPS.HiltonDirect.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HiltonDirectEntities : DbContext
    {
        public HiltonDirectEntities()
            : base("name=HiltonDirectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DirectLeadRequest> DirectLeadRequests { get; set; }
        public virtual DbSet<EchannelRequest> EchannelRequests { get; set; }
        public virtual DbSet<FollowUpActivity> FollowUpActivities { get; set; }
        public virtual DbSet<MeetingClass> MeetingClasses { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
    }
}