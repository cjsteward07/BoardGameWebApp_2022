using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_With_EF_2022.DataAccessLayer;
using MVC_With_EF_2022.Models;

namespace MVC_With_EF_2022.Controllers
{
    public class CourseController : Controller
    {
        private SchoolContext db = new SchoolContext();
        public IActionResult Index()
        {
            return View(db.Courses.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new BadHttpRequestException("No Id Provided");
            }

            //include is used here because we're using a foreign key
            Course course = db.Courses
                .Where(x => x.CourseID == id)
                .Include(i => i.Enrollments) //line you add that tells EF to dive down even deeper. Hey, give me the courses and include the enrollment data for those courses
                .FirstOrDefault(); //Give me the first one

            //if query doesn't bring anything it hits the default from FirstOrDefault() then it hits the bottom if block because the default is currently null

            if (course == null)
            {
                throw new BadHttpRequestException("Course not found");
            }

            // Looping through the enrollment data (all Ids), and populating the student data using the ID
            //here we go through and populate the student information for that enrollment. For every enrollment we're upating the student with actual student information. The reason you have to use a for loop instead of a foreach loop you cannot change the collection
            for (int i = 0; i < course.Enrollments.Count; i++)
            {
                course.Enrollments[i].Student = db.Students.FirstOrDefault(x => x.ID == course.Enrollments[i].StudentID);
            }
            return View(course);
        }
    }
}
