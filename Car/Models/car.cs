namespace Car.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("car")]
    public partial class car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public car()
        {
            car_details = new HashSet<car_details>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public int Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<car_details> car_details { get; set; }
    }
}
