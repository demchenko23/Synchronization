namespace Synchronization.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SynchronContext : DbContext
    {
        public SynchronContext()
            : base("name=SynchronizationContext1")
        {
        }

        public virtual DbSet<ComputerModel> ComputerModels { get; set; }
        public virtual DbSet<PhoneModel> PhoneModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComputerModel>()
                .HasMany(e => e.Phones)
                .WithMany(e => e.Computers)
                .Map(m => m.ToTable("PhoneComputer").MapLeftKey("Comp_IdComp"));
        }
    }
}
