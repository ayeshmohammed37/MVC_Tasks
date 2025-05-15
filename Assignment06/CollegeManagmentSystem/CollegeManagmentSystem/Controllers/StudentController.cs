using CollegeManagmentSystem.Models;
using CollegeManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagmentSystem.Controllers
{
    public class StudentController : Controller
    {

        StudentBL studentbl = new StudentBL();
        DepartmentBL departmentbl = new DepartmentBL();
        CourseBL coursebl = new CourseBL();

        public IActionResult Index()
        {
            StudentIndexViewModel model = new StudentIndexViewModel();
            model.Students = studentbl.GetAll();
            model.Departments = departmentbl.GetAll();

            return View(model);
        }


        public IActionResult Add()
        {
            var addStudentViewModel = new AddStudentViewModel();
            addStudentViewModel.Departments = departmentbl.GetAll();


            return View(addStudentViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAdd(AddStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();
                student.Name = model.Name;
                student.Age = model.Age;
                student.DepartmentId = model.DeptId;
                studentbl.Add(student);
                return RedirectToAction(nameof(Index));
            }
            model.Departments = departmentbl.GetAll();
            return View("Add", model);
        }

        public IActionResult Edit(int id)
        {
            Student student = studentbl.GetById(id);
            EditStudentViewModel model = new EditStudentViewModel();
            model.Id = id;
            model.Name = student.Name;
            model.Age = student.Age;
            model.DeptId = student.DepartmentId;
            model.Departments = departmentbl.GetAll();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(EditStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();
                student.Id = model.Id;
                student.Name = model.Name;
                student.Age = model.Age;
                student.DepartmentId = model.DeptId;

                //update student
                studentbl.Update(student);
                return RedirectToAction(nameof(Index));
            }
            return View("Edit", model);
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

        [HttpPost]
        public IActionResult Search(SearchViewModel model)
        {
            if (model.Name == null && model.DepartMentId ==null)
                return RedirectToAction(nameof(Index));

             List<Student> students = studentbl.Search(model.Name, model.DepartMentId);

            return View(students);
                
        }

    }
}
