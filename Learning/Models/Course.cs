// A class for defining course model 

using System.ComponentModel.DataAnnotations.Schema;

namespace Learning.Models{
    public class Course{

        // properties
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID {get;  set;}
        public string Title {get; set;}
        public int Credits {get; set;}
        
        // navigation properties
        public ICollection<Enrollment> Enrollments {get; set;}
    }
}