namespace WackerDrei.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hobby")]
    public partial class Hobby
    {
        public Hobby()
        {
            Players = new HashSet<Player>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("Hobby")]
        [Required]
        public string Hobbyname { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
