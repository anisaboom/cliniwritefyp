namespace FYP2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Referral")]
    public partial class Referral
    {
        public int id { get; set; }

        public DateTime dateofreferral { get; set; }

        [Required]
        [StringLength(50)]
        public string referredby { get; set; }

        public int clientid { get; set; }

        public virtual Client Client { get; set; }
    }
}
