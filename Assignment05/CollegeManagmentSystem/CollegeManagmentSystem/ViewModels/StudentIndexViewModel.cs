using System.ComponentModel.DataAnnotations;
using CollegeManagmentSystem.Models;

namespace CollegeManagmentSystem.ViewModels
{
    public class StudentIndexViewModel
    {
        public List<Student> Students { get; set; }

        [Display(Name="Full Name")]
        public string? Name { get; set; }

        [Display(Name="Department")]
        public int? DepartMentId { get; set; }

        public List<Department> Departments { get; set; }
    }
}
