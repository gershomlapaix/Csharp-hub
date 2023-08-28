using Learning.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning.Data{
    
    public class LearningContext: DbContext{
        public LearningContext(DbContextOptions<LearningContext> options): base(options){}

        public DbSet<Course> Courses {get; set;}
        public DbSet<Enrollment> Enrollments {get; set;}
        public DbSet<Student> Students {get; set;}

        // Make own database table names
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}