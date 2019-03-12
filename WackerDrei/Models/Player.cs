namespace WackerDrei.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Player")]
    public partial class Player : Person
    {
        public Player()
        {
            Blogs = new HashSet<Blog>();
            Events = new HashSet<Event>();
            Functions = new HashSet<Function>();
            Hobbies = new HashSet<Hobby>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string Position { get; set; }

        public int? Number { get; set; }

        public DateTime Birthday { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public int DioptreId { get; set; }

        public string DioptreDescription { get; set; }

        [Required]
        public string Job { get; set; }
        
        public string MottoOfLife { get; set; }

        public string Dream { get; set; }

        [Required]
        public string OwnDescription { get; set; }

        public string TeamDescription { get; set; }

        public string DailyNicotine { get; set; }

        public string BeerAfterTraining { get; set; }

        public bool Active { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }

        public virtual Dioptre Dioptre { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual Injury Injury { get; set; }

        public virtual ICollection<Function> Functions { get; set; }

        public virtual ICollection<Hobby> Hobbies { get; set; }

        public virtual ICollection<Carrier> Carriers { get; set; }

        public virtual ICollection<Injury> Injuries { get; set; }

    }
}
