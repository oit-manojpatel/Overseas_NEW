namespace Overseas.Manager.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbOITReporting : DbContext
    {
        public dbOITReporting()
            : base("name=dbOITReporting")
        {
        }

        public virtual DbSet<clientMaster> clientMasters { get; set; }
        public virtual DbSet<domainMaster> domainMasters { get; set; }
        public virtual DbSet<emailSendingHistory> emailSendingHistories { get; set; }
        public virtual DbSet<RoleMaster> RoleMasters { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblCountry> tblCountries { get; set; }
        public virtual DbSet<tblState> tblStates { get; set; }
        public virtual DbSet<userMaster> userMasters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<domainMaster>()
                .HasMany(e => e.clientMasters)
                .WithRequired(e => e.domainMaster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoleMaster>()
                .HasMany(e => e.userMasters)
                .WithRequired(e => e.RoleMaster)
                .HasForeignKey(e => e.RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCountry>()
                .HasMany(e => e.clientMasters)
                .WithRequired(e => e.tblCountry)
                .HasForeignKey(e => e.countryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCountry>()
                .HasMany(e => e.tblStates)
                .WithRequired(e => e.tblCountry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCountry>()
                .HasMany(e => e.userMasters)
                .WithRequired(e => e.tblCountry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblState>()
                .HasMany(e => e.clientMasters)
                .WithRequired(e => e.tblState)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblState>()
                .HasMany(e => e.userMasters)
                .WithRequired(e => e.tblState)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<userMaster>()
                .HasMany(e => e.clientMasters)
                .WithRequired(e => e.userMaster)
                .WillCascadeOnDelete(false);
        }
    }
}
