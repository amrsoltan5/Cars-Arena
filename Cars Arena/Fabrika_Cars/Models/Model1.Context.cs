﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fabrika_Cars.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class carsArena : DbContext
    {
        public carsArena()
            : base("name=carsArena")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<adv_copmanies> adv_copmanies { get; set; }
        public virtual DbSet<bank> bank { get; set; }
        public virtual DbSet<buyer> buyer { get; set; }
        public virtual DbSet<messages> messages { get; set; }
        public virtual DbSet<sellers> sellers { get; set; }
        public virtual DbSet<sellers_adv_copmanies> sellers_adv_copmanies { get; set; }
        public virtual DbSet<users> users { get; set; }
    }
}