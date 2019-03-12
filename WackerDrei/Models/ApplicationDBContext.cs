using Microsoft.AspNet.Identity.EntityFramework;

namespace WackerDrei.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Association> Associations { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Bodypart> Bodyparts { get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Dioptre> Dioptres { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Hobby> Hobbies { get; set; }
        public virtual DbSet<Injury> Injuries { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Player> Players { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Association>()
                .HasMany(e => e.Carriers)
                .WithRequired(e => e.Association)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Blog>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Blog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bodypart>()
                .HasMany(e => e.Injuries)
                .WithRequired(e => e.Bodypart)
                .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<Categorie>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Categorie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dioptre>()
                .HasMany(e => e.Players)
                .WithRequired(e => e.Dioptre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Function>()
                .HasMany(e => e.Players)
                .WithMany(e => e.Functions)
                .Map(m => m.ToTable("Player_Function").MapLeftKey("FunctionId").MapRightKey("PlayerId"));

            modelBuilder.Entity<Hobby>()
                .HasMany(e => e.Players)
                .WithMany(e => e.Hobbies)
                .Map(m => m.ToTable("PlayerHobby").MapLeftKey("HobbyId").MapRightKey("PlayerId"));

            modelBuilder.Entity<Player>()
                .HasMany(e => e.Blogs)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.Carriers)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.Injuries)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete(false);
        }
    }
}
