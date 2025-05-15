using CollegeManagmentSystem.Models;
using CollegeManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagmentSystem.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBL departmentBL = new DepartmentBL();
        TeacherBL teacherBL = new TeacherBL();
        StudentBL studentBL = new StudentBL();
        CourseBL courseBL = new CourseBL();

        public IActionResult Index()
        {
            List<Department> departments = departmentBL.GetAll();
            return View(departments);
        }

        public IActionResult ShowDetails(int id)
        {
            DepartmentDetailsViewModel departmentDetailsViewModel = new DepartmentDetailsViewModel();

            Department department = departmentBL.GetById(id);
            List<string> teachers = teacherBL.GetAllByDept(id)
                .Select(x => x.Name).ToList();
            List<string> students = studentBL.SearchByDepartment(id)
                .Select(x => x.Name).ToList();
            List<string> courses = courseBL.GetAllByDept(id)
                .Select(x => x.Name)
                .ToList();


            departmentDetailsViewModel.DeptName = department.Name;
            departmentDetailsViewModel.MgrName = department.MgrName;
            departmentDetailsViewModel.TeachersName = teachers;
            departmentDetailsViewModel.StudentsName = students;
            departmentDetailsViewModel.CoursesName = courses;

            return View(departmentDetailsViewModel);
        }


        // /Department/Add
        public IActionResult Add()
        {
            return View();
        }

        // /Department/SaveAdd?Name=AI S&MgrName=Dr.Ahmed
        [HttpPost]
        public IActionResult SaveAdd(Department department)
        {
            if (department.Name != null)
            {
                departmentBL.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View("Add", department);
        }

        public IActionResult Remove(int id)
        {
            departmentBL.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        

        
    }
}
