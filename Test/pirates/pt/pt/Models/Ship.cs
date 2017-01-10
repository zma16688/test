namespace pt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ship
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ship()
        {
            Crews = new HashSet<Crew>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage ="name can not over 20 chars")]
        public string Name { get; set; }

        [Required]
        [StringLength(20,ErrorMessage ="can not over 20 char")]
        public string Type { get; set; }

        public int Ton { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Crew> Crews { get; set; }
    }
}
