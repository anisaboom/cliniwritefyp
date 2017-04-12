using System.ComponentModel;

namespace FYP2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appointment")]
    public partial class Appointment
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Start Time")]
        public string starttime { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("End Time")]
        public string endtimee { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public string date { get; set; }
        [DisplayName("Full Name")]
        public int clientid { get; set; }

        public virtual Client Client { get; set; }
    }
}
