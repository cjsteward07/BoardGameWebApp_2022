namespace MVC_With_EF_2022.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public virtual List<Enrollment> Enrollments { get; set; }
        //I think this is creates the relation with foreign key?
        //potential to be related to many students
    }

}
