using CollegeManagmentSystem.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagmentSystem.Models
{
    public class CourseBL
    {
        CollegeManagmentSystemDbContext context = new CollegeManagmentSystemDbContext();


        public Course GetById(int id)
        {
            return context.Courses
                .Include(c => c.Department)
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Course> GetAll()
        {
            return context.Courses.Include(c => c.Department).Include(c => c.Teachers).Include(c => c.StuCrsRess).ToList();
        }

        public List<Course> GetAllByDept(int? id)
        {
            return context.Courses
                .Where(course => course.DepartmentId == id)
                .ToList();
        }

        public void Add(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void Update(Course course)
        {
            //Course dbCourse = GetById(course.Id);
            //if (dbCourse != null)
            //{
            //    dbCourse.Name = course.Name;
            //    dbCourse.Degree = course.Degree;
            //    dbCourse.MinDegree = course.MinDegree;
            //    dbCourse.DepartmentId = course.DepartmentId;
            //    dbCourse.Teachers = course.Teachers;
            //    context.SaveChanges();
            //}
            context.Courses.Update(course);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Course dbCourse = GetById(id);
            context.Courses.Remove(dbCourse);
            context.SaveChanges();
        }
    }
}
