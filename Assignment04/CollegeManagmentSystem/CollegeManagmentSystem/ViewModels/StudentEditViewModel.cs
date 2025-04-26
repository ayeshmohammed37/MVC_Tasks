using System.ComponentModel.DataAnnotations;
using CollegeManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeManagmentSystem.ViewModels
{
    public class StudentEditViewModel
    {
        public StudentEditViewModel()
        {
            this.Departments = this.DepartmentNameAndValue();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }

        public List<SelectListItem> Departments;

        public  List<SelectListItem> DepartmentNameAndValue ()
        {
            DepartmentBL departmentBL = new DepartmentBL ();
            List<Department> Departments = departmentBL.GetAll();
            List<SelectListItem> items = new List<SelectListItem> ();

            foreach (var item in Departments)
            {
                items.Add(new SelectListItem
                {
                    Value = $"{item.Id}",
                    Text = item.Name,
                    Selected = (item.Id == (this?.DepartmentId?? -1)) ? true : false
                });
            }
            return items;
        }

        public Student Parse()
        {
            Student student = new Student()
            {
                Name = this.Name,
                Age = this.Age,
                DepartmentId = this.DepartmentId,
            };

            return student;

        }
        
    }
}
