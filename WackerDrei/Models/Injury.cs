namespace WackerDrei.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Injury")]
    public partial class Injury
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public int BodyPartId { get; set; }

        public int PlayerId { get; set; }

        public virtual Bodypart Bodypart { get; set; }

        public virtual Player Player { get; set; }
    }
}
