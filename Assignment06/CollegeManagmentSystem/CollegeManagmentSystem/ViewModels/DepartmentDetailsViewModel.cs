namespace CollegeManagmentSystem.ViewModels
{
    public class DepartmentDetailsViewModel
    {
        public string DeptName { get; set; }
        public string MgrName { get; set; }
        public List<string> TeachersName { get; set; }
        public List<string> CoursesName { get; set; }
        public List<string> StudentsName { get; set; }
    }
}
