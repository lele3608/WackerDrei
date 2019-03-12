namespace WackerDrei.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment : Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int BlogId { get; set; }

        public int PersonId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
