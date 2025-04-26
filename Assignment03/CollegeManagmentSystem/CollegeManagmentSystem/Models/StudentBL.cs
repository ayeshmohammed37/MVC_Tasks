using CollegeManagmentSystem.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagmentSystem.Models
{
    public class StudentBL
    {
        CollegeManagmentSystemDbContext context = new CollegeManagmentSystemDbContext();

        public List<Student> GetAll()
        {
            return context.Students
                .Include(S => S.Department)
                .Include(S => S.StuCrsRess)
                .ThenInclude(s => s.Course)
                .ToList();
        }

        public Student GetById(int id)
        {
            return context.Students
                .Include(S => S.Department)
                .Include(S => S.StuCrsRess)
                .ThenInclude(s => s.Course)
                .FirstOrDefault(s => s.Id == id);
        }

        public void Add(Student student)
        {
            context.Students
                .Add(student);

            context.SaveChanges();
        }
    }
}
