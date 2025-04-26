using CollegeManagmentSystem.DbContexts;
using CollegeManagmentSystem.ViewModels;
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

        public void Update(int id, StudentEditViewModel SEVM)
        {
            context.Students.FirstOrDefault(s => s.Id == id).Name = SEVM.Name;
            context.Students.FirstOrDefault(s => s.Id == id).Age = SEVM.Age;
            context.Students.FirstOrDefault(s => s.Id == id).DepartmentId = SEVM.DepartmentId;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }

        public List<Student> SearchByName(string name)
        {
            return context.Students
                .Where(s => s.Name == name)
                .Include(S => S.Department)
                .Include(S => S.StuCrsRess)
                .ThenInclude(s => s.Course)
                .ToList();
        }

        public List<Student> SearchByDepartment(int departmentId)
        {
            return context.Students
                .Where(s => s.DepartmentId == departmentId)
                .Include(S => S.Department)
                .Include(S => S.StuCrsRess)
                .ThenInclude(s => s.Course)
                .ToList();
        }
    }
}

