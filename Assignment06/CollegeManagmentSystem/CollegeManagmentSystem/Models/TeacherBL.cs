using CollegeManagmentSystem.DbContexts;

namespace CollegeManagmentSystem.Models
{
    public class TeacherBL
    {
        CollegeManagmentSystemDbContext context = new CollegeManagmentSystemDbContext();

        public List<Teacher> GetAllByDept(int id)
        {
            return context.Teachers
                .Where(teacher => teacher.DepartmentId == id)
                .ToList();
        }
    }
}
