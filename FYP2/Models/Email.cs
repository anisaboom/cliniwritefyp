using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FYP2.Models
{
    public class Email
    {
        public int ID { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Message { get; set; }
    }

       public class EmailDBContext : DbContext
        {
            public DbSet<Email> Emails { get; set; }
        }
    }
