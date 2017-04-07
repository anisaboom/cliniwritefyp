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

        public string starttime { get; set; }

        [Required]
        [StringLength(50)]
       
        public string endtimee { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Date)]
        public string date { get; set; }

        public int clientid { get; set; }

        public virtual Client Client { get; set; }
    }
}
