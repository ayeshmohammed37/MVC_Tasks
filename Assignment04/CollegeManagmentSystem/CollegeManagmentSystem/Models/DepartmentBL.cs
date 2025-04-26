using CollegeManagmentSystem.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagmentSystem.Models
{
    public class DepartmentBL
    {
        CollegeManagmentSystemDbContext context = new CollegeManagmentSystemDbContext();

        public List<Department> GetAll()
        {
            return context.Departments
                .Include(D => D.Students)
                .Include(D => D.Teachers)
                .Include(D => D.Courses)
                .ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments
                .Include(D => D.Students)
                .Include(D => D.Teachers)
                .Include(D => D.Courses)
                .FirstOrDefault(D => D.Id == id);
        }

        public void Add(Department department)
        {
            context.Departments
                .Add(department);

            context.SaveChanges();
        }

        public void Remove(int id)
        {
            Department department = GetById(id);
            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();

            }
        }
        public List<string> GetNames()
        {
            return context.Departments
                .Include(D => D.Students)
                .Include(D => D.Teachers)
                .Include(D => D.Courses)
                .Select(d => d.Name)
                .ToList();
        }

        public List<string> GetStudentNames(string departmentName)
        {
            return context.Departments
                .Include(D => D.Students)
                .Include(D => D.Teachers)
                .Include(D => D.Courses)
                .First(D => D.Name == departmentName)
                .Students.Where(stu => stu.Age < 20)
                .Select(stu => stu.Name)
                .ToList();
        }
    }
}
