using CollegeManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagmentSystem.Controllers
{
    public class StudentController : Controller
    {

        StudentBL studentbl = new StudentBL();
        

        // /student/ShowAll 
        public IActionResult ShowAll()
        {
            List<Student> students = studentbl.GetAll();
            return View("ShowAll", students);
        }

        // /Student/ShowDetails?id=3 
        public IActionResult ShowDetails(int id)
        {
            Student student = studentbl.GetById(id);
            return View("ShowDetails", student);
        }

        public IActionResult Add()
        {
            
            return View("Add");
        }

        // /Student/SaveAdd?name=ahmed&age=18&DepartmentId=2
        public IActionResult SaveAdd(Student student)
        {
            if (student.Name != null)
            {
                studentbl.Add(student);
                return RedirectToAction(nameof(ShowAll));
            }
            return View("Add",student);
        }
    }
}
