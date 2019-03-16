namespace Car.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class car_details
    {
        public int id { get; set; }

        [Key]
        public int car_id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string color { get; set; }

        [Required]
        [StringLength(50)]
        public string seats { get; set; }

        public virtual car car { get; set; }
    }
}
