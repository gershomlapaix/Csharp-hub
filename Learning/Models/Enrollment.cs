// This contains enrollment class for handling many-to-many relationship between student and course
namespace Learning.Models{

    // Grade constrants
    public enum Grade{
        A,B,C,D,F
    }
    public class Enrollment{

        // properties
        public int EnrollmentID {get; set;}
        public int CourseID {get; set;}
        public int StudentID {get; set;}
        public Grade? Grade {get; set;}


        // navigation properties
        public Course Course {get; set;}
        public Student Student {get; set;}
    }
}