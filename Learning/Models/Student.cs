// A class for defining student model

namespace Learning.Models{
    public class Student{

        // properties
        public int ID{get; set;}
        public string LastName {get; set;}
        public string FirstName {get; set;}
        public DateTime EnrollmentDate {get; set;}
        
        // navigation properties
        public ICollection<Enrollment> Enrollments {get; set;}
    }
}