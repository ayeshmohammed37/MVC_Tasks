namespace CollegeManagmentSystem.Models
{
    public class StuCrsRes
    {
        //Grade: A,A-,B+,B,B-,C+,C,C-,D+,D,F,FR
        public String Grade { get; set; }

        public int? CourseId { get; set; }
        public Course Course { get; set; }

        public int? StudentId { get; set; }
        public Student Student { get; set; }
    }
}
