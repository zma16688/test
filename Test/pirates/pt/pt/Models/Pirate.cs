using System;
using System.ComponentModel.DataAnnotations;

namespace pt.Models
{
    using CustomDataAnnotation;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pirate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pirate()
        {
            Crews = new HashSet<Crew>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        [CurrentDate(ErrorMessage ="please input a valid date")]
        public DateTime Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Crew> Crews { get; set; }
    }
}

namespace CustomDataAnnotation
{
    public class CurrentDateAttribute:ValidationAttribute
    {
        public CurrentDateAttribute() { }
        public override bool IsValid(object value)
        {
            var d = (DateTime)value;

            return System.DateTime.Now>=d ? true : false;
        }
    }
}
