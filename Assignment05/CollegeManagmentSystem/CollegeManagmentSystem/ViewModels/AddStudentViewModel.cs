using System.ComponentModel.DataAnnotations;
using CollegeManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeManagmentSystem.ViewModels
{
    public class AddStudentViewModel
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage ="Name is required")]
        [RegularExpression(@"^[A-Z][a-zA-Z]*\s[A-Z][a-zA-Z]*$", ErrorMessage = "Please enter a valid name with a capital first letter for both first and last name, separated by a single space.")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int Age { get; set; }

        [Display(Name ="Department")]
        [Required(ErrorMessage = "Department is required")]
        public int DeptId { get; set; }

        
        public List<Department>? Departments { get; set; }

    }
}
