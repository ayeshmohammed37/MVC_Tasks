namespace CollegeManagmentSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Degree { get; set; }
        public decimal MinDegree { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<StuCrsRes> StuCrsRess { get; set; }

    }
}
