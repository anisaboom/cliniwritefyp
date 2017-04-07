namespace FYP2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<PHQ9> PHQ9 { get; set; }
        public virtual DbSet<Referral> Referrals { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .Property(e => e.starttime)
                .IsUnicode(false);

            modelBuilder.Entity<Appointment>()
                .Property(e => e.endtimee)
                .IsUnicode(false);

            modelBuilder.Entity<Appointment>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.phonenumber)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.emailaddress)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.nationality)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.placeofbirth)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.addressline1)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.addressline2)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.postcode)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.nhsnumber)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Sessions)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Referrals)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Referral>()
                .Property(e => e.referredby)
                .IsUnicode(false);

            modelBuilder.Entity<Session>()
                .Property(e => e.sessiondate)
                .IsUnicode(false);

            modelBuilder.Entity<Session>()
                .Property(e => e.sessionnote)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<FYP2.Models.Email> Emails { get; set; }
    }
}
