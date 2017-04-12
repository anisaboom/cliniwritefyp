namespace FYP2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Session")]
    public partial class Session
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        [DataType(DataType.Date)]
        public string sessiondate { get; set; }

        [Required]
        public string sessionnote { get; set; }

        public int sessioncount { get; set; }

        public int clientid { get; set; }

        public virtual Client Client { get; set; }
    }
}
