using CollegeManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagmentSystem.Controllers
{
    public class CourseController : Controller
    {
        CourseBL courseBL = new CourseBL();
        DepartmentBL departmentBL = new DepartmentBL();

        public IActionResult Index()
        {
            List<Course> courses = courseBL.GetAll();
            return View(courses);
        }

        public IActionResult Add()
        {
            ViewBag.Departments = departmentBL.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAdd(Course course)
        {
            ViewBag.Departments = departmentBL.GetAll();

            if (ModelState.IsValid)
            {
                courseBL.Add(course);
                return RedirectToAction(nameof(Index));
            }
            return View("Add",course);
        }

        public IActionResult Edit(int id)
        {
            Course course = courseBL.GetById(id);
            ViewBag.Departments = departmentBL.GetAll();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(Course course)
        {
            ViewBag.Departments = departmentBL.GetAll();

            if (ModelState.IsValid)
            {
                courseBL.Update(course);
                return RedirectToAction(nameof(Index));
            }
            return View("Edit", course);
        }

        public IActionResult Warning(int id)
        {
            Course course = courseBL.GetById(id);
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            courseBL.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
