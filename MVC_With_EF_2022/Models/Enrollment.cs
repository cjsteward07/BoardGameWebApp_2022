namespace MVC_With_EF_2022.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    //many to many relation
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }

}
