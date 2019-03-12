namespace WackerDrei.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime Starttime { get; set; }

        public DateTime? Endtime { get; set; }

        [Required]
        public string Description { get; set; }

        public int PlayerId { get; set; }

        public int CategorieId { get; set; }

        public virtual Categorie Categorie { get; set; }

        public virtual Player Player { get; set; }
    }
}
