using Microsoft.EntityFrameworkCore;

namespace apitest.Data {
    public class SchoolDbContext : DbContext {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) {
        }

        public DbSet<Models.Student> Students { get; set; }
        public DbSet<Models.Classroom> Classrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Models.Student>()
                .HasOne(s => s.Classroom)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassroomId);
        }
    }
}
