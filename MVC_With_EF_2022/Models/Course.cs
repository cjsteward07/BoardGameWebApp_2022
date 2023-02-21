using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_With_EF_2022.Models
{
    public class Course
    {
        //This tells EF to create column but don't make it an auto number because I'm going to provide values
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual List<Enrollment> Enrollments { get; set; }
    }

}
