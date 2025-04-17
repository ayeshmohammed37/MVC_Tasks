using CollegeSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.Controllers
{
    public class StudentController : Controller
    {
        ///student/ShowAll 
        public IActionResult ShowAll()
        {
            StudentBL studentBL = new StudentBL();
            List<Student> students = studentBL.GetAll();
            return View("ShowAll", students);
        }


        ///Student/ShowDetails? id = 3
        public IActionResult ShowDetails(int id)
        {
            StudentBL studentBL = new StudentBL();
            Student student = studentBL.Get(id);
            return View("ShowDetails", student);

        }
    }
}
