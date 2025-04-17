namespace CollegeSystem.Models
{
    public class StuCrsRes
    {
        public string Grade { get; set; } //A,A-,B+,B,B-,C+,C,C-,D+,D,F,FR

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
