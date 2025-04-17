using CollegeSystem.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CollegeSystem.Models
{
    public class StudentBL
    {
        CollegeSystemDbContext context = new CollegeSystemDbContext();

        public List<Student> GetAll()
        {
            return context.Students.Include(s => s.Department).ToList();
        }

        public Student Get(int id)
        {
            return context.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
        }
    }
}
