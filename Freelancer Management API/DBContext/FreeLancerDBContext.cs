using Freelancer_Management_API.Model;
using Microsoft.EntityFrameworkCore;
namespace Freelancer_Management_API.DBContext
{
    public class FreeLancerDBContext:DbContext
    {
        public FreeLancerDBContext(DbContextOptions<FreeLancerDBContext> options)
          : base(options)
        {
        }

        public DbSet<MC_FreeLancer> Freelancers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MC_FreeLancer>()
            .ToTable("FreeLancers");  // This matches your database table name

            modelBuilder.Entity<MC_FreeLancer>()
                .Property(f => f.FL_Skillsets)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                );

            modelBuilder.Entity<MC_FreeLancer>()
                .Property(f => f.FL_Hobbies)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                );
        }
    }
}
