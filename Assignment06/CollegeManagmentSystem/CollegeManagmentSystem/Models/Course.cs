using System.ComponentModel.DataAnnotations;

namespace CollegeManagmentSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "The Course Name is required.")]
        [StringLength(150, ErrorMessage = "The Course Name cannot exceed {1} characters.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter Course Degree")]
        [Range(0, 100, ErrorMessage = "The Degree must be between {1} and {2}.")]
        [Display(Name ="Course Dgree")]
        [DataType(DataType.Text)]
        public decimal Degree { get; set; }

        [Range(0, 100, ErrorMessage = "The Minimum Degree must be between {1} and {2}.")]
        [Display(Name ="Minimum Degree for Course")]
        [DataType(DataType.Text)]
        public decimal MinDegree { get; set; }

        [Display(Name ="Department")]
        [Range(1,4, ErrorMessage = "Select Department")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public List<Teacher>? Teachers { get; set; }

        public List<StuCrsRes>? StuCrsRess { get; set; }

    }
}
