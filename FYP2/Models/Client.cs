using System.ComponentModel;

namespace FYP2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Appointments = new HashSet<Appointment>();
            Sessions = new HashSet<Session>();
            Referrals = new HashSet<Referral>();
        }
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string firstname { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string lastname { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        //  https://blogs.msdn.microsoft.com/stuartleeks/2011/01/25/asp-net-mvc-3-integrating-with-the-jquery-ui-date-picker-and-adding-a-jquery-validate-date-range-validator/
        public DateTime dateofbirth { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Gender")]
        public string gender { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,13}$", ErrorMessage = "Please enter valid phone no.")]
        public string phonenumber { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string emailaddress { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Nationality")]
        public string nationality { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Place of Birth")]
        public string placeofbirth { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Address Line 1")]
        public string addressline1 { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Address Line 2")]
        public string addressline2 { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Postcode")]
        public string postcode { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("NHS Number")]
        public string nhsnumber { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Session> Sessions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Referral> Referrals { get; set; }

        [DisplayName("Full Name")]
        public string fullname
        {
            get { return firstname + " " + lastname; }
        }

    }
}
