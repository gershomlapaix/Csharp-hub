using Learning.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning.Data{
    
    public class LearningContext: DbContext{
        public LearningContext(DbContextOptions<LearningContext> options): base(options){}

        public DbSet<Course> courses {get; set;}
        public DbSet<Enrollment> Enrollments {get; set;}
        public DbSet<Student> Students {get; set;}
    }
}