using CollegeManagmentSystem.Models;
using CollegeManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagmentSystem.Controllers
{
    public class StudentController : Controller
    {

        StudentBL studentbl = new StudentBL();
        DepartmentBL departmentbl = new DepartmentBL();
        
        public IActionResult Index()
        {
            ViewBag.Departments = departmentbl.GetAll();
            List<Student> students = studentbl.GetAll();
            return View("Index", students);
        }
        

        public IActionResult Add()
        {
            var studentEditVM = new StudentEditViewModel();
            return View("Add", studentEditVM);
        }



        public IActionResult SaveAdd(StudentEditViewModel SEVM)
        {
            if (SEVM.Name != null)
            {
                var student = SEVM.Parse();
                studentbl.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View("Add", SEVM);
        }

        public IActionResult Edit(int id)
        {   
            var student = studentbl.GetById(id);
            var studentEditVM = new StudentEditViewModel();
            studentEditVM.Id = id;
            studentEditVM.Name = student.Name;
            studentEditVM.Age = student.Age;
            studentEditVM.DepartmentId = student.DepartmentId ?? 0;
            return View("Edit", studentEditVM);
        }

        public IActionResult SaveEdit(int id, StudentEditViewModel SEVM)
        {
            if (SEVM.Name != null)
            {
                //update student
                studentbl.Update(id, SEVM);
                return RedirectToAction(nameof(Index));
            }
            return View("Edit", SEVM);
        }

        public IActionResult Warning(int id)
        {
            return View("Warning",studentbl.GetById(id));
        }

        public IActionResult Delete(int id)
        {
            studentbl.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult FindByName(string name)
        {
            if (name != null)
            {
                var students = studentbl.SearchByName(name);
                return View("DisplayAll", students);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult FindByDepartment(int DepartmentId)
        {
            var students = studentbl.SearchByDepartment(DepartmentId);
            return View("DisplayAll", students);
        }
    }
}
