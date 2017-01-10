namespace pt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Crew")]
    public partial class Crew
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Ship")]
        public int ShipId { get; set; }
        [ForeignKey("Pirate")]
        public int PirateId { get; set; }

        [Required]
        [Column(TypeName ="money")]
        public decimal Booty { get; set; }

        [Column(TypeName = "int")]
        [Display(Name = "Number Of Crew")]
        public int numOfCrew { get; set; }

        [Display(Name = "Experience Level")]
        [Range(1,5)]
        public string experience { get; set; }

        public virtual Pirate Pirate { get; set; }

        public virtual Ship Ship { get; set; }
        
    }
}
