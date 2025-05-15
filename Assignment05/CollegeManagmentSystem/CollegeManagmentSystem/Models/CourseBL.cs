using CollegeManagmentSystem.DbContexts;

namespace CollegeManagmentSystem.Models
{
    public class CourseBL
    {
        CollegeManagmentSystemDbContext context = new CollegeManagmentSystemDbContext();

        public List<Course> GetAllByDept(int? id)
        {
            return context.Courses
                .Where(course => course.DepartmentId == id)
                .ToList();
        }
    }
}
