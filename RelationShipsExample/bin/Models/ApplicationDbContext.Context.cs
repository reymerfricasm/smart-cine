﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RelationShipsExample.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SmartCinetEntities : DbContext
    {
        public SmartCinetEntities()
            : base("name=SmartCinetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Cinema> Cinema { get; set; }
        public virtual DbSet<Classification> Classification { get; set; }
        public virtual DbSet<Day> Day { get; set; }
        public virtual DbSet<Director> Director { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MoviePerCinema> MoviePerCinema { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Schelude> Schelude { get; set; }
        public virtual DbSet<Studio> Studio { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
