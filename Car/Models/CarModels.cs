namespace Car.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CarModels : DbContext
    {
        public CarModels()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<car> cars { get; set; }
        public virtual DbSet<car_details> car_details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<car>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<car>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<car>()
                .HasMany(e => e.car_details)
                .WithRequired(e => e.car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<car_details>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<car_details>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<car_details>()
                .Property(e => e.seats)
                .IsUnicode(false);
        }
    }
}
