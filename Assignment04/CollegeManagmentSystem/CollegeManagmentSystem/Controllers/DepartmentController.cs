using CollegeManagmentSystem.Models;
using CollegeManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagmentSystem.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBL departmentBL = new DepartmentBL();
        public IActionResult Index()
        {
            List<Department> departments = departmentBL.GetAll();
            return View("Index", departments);
        }

        public IActionResult ShowDetails(int id)
        {
            Department department = departmentBL.GetById(id);
            return View("ShowDetails",department);
        }


        // /Department/Add
        public IActionResult Add()
        {
            return View("Add");
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

        public IActionResult Status()
        {
            List<string> DepNames = departmentBL.GetNames();

            List<DepartmentStatusViewModel> departmentsVM = new List<DepartmentStatusViewModel>();

            foreach (string name in DepNames)
            {
                List<string> temp = departmentBL.GetStudentNames(name);

                departmentsVM.Add(new DepartmentStatusViewModel()
                {
                    DepartmentName = name,
                    StudentNames = temp,
                    DepartmentState = temp.Count > 50 ? "Main" : "Branch"
                });
            }
            return View("Status", departmentsVM);
        }

        
    }
}
