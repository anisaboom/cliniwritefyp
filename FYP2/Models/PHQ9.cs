namespace FYP2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PHQ9
    {
        public int id { get; set; }

        public int q1 { get; set; }

        public int q2 { get; set; }

        public int q3 { get; set; }

        public int q4 { get; set; }

        public int q5 { get; set; }

        public int q6 { get; set; }

        public int q7 { get; set; }

        public int q8 { get; set; }

        public int q9 { get; set; }

        public int q10 { get; set; }

        public int appointmentid { get; set; }
    }
}
