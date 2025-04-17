using CollegeSystem.Contexts;
using CollegeSystem.Models;

namespace CollegeSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CRUD opr for CollegeDB add some random recordes for tables
            Random rnd = new Random();
            string[] names = { "John", "Alice", "Michael", "Sarah", "David", "Emma", "Chris", "Olivia", "James", "Sophia" };
            string[] grades = { "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "F", "FR" };

            var departments = Enumerable.Range(1, 3).Select(id => new Department
            {
                //Id = id,
                Name = $"Department {id}",
                MgrName = names[rnd.Next(names.Length)],
                Courses = new List<Course>(),
                Teachers = new List<Teacher>(),
                Students = new List<Student>()
            }).ToList();

            var courses = Enumerable.Range(1, 5).Select(id =>
            {
                var dept = departments[rnd.Next(departments.Count)];
                var course = new Course
                {
                    //Id = id,
                    Name = $"Course {id}",
                    Degree = rnd.Next(60, 100),
                    MinDegree = rnd.Next(40, 60),
                    Department = dept,
                    DepartmentId = dept.Id,
                    StuCrsRess = new List<StuCrsRes>(),
                    Teachers = new List<Teacher>()
                };
                dept.Courses.Add(course);
                return course;
            }).ToList();

            var teachers = Enumerable.Range(1, 5).Select(id =>
            {
                var course = courses[rnd.Next(courses.Count)];
                var dept = course.Department;
                var teacher = new Teacher
                {
                    //Id = id,
                    Name = $"Teacher {names[rnd.Next(names.Length)]}",
                    Salary = rnd.Next(5000, 10000),
                    Address = $"Address {id}",
                    Department = dept,
                    DepartmentId = dept.Id,
                    Course = course,
                    CourseId = course.Id
                };
                dept.Teachers.Add(teacher);
                course.Teachers.Add(teacher);
                return teacher;
            }).ToList();

            var students = Enumerable.Range(1, 30).Select(id =>
            {
                var dept = departments[rnd.Next(departments.Count)];
                var student = new Student
                {
                    //Id = id,
                    Name = $"Student {names[rnd.Next(names.Length)]}{id}",
                    Age = rnd.Next(18, 25),
                    Department = dept,
                    DepartmentId = dept.Id,
                    StuCrsRess = new List<StuCrsRes>()
                };
                dept.Students.Add(student);

                // Assign 2-4 courses randomly to each student
                var studentCourses = courses.OrderBy(x => rnd.Next()).Take(rnd.Next(2, 5)).ToList();
                foreach (var course in studentCourses)
                {
                    var res = new StuCrsRes
                    {
                        Grade = grades[rnd.Next(grades.Length)],
                        Student = student,
                        //StudentId = student.Id,
                        Course = course,
                        //CourseId = course.Id
                    };
                    student.StuCrsRess.Add(res);
                    course.StuCrsRess.Add(res);
                }

                return student;
            }).ToList();


            CollegeSystemDbContext context = new CollegeSystemDbContext();
            context.Departments.AddRange(departments);
            context.Courses.AddRange(courses);
            context.Teachers.AddRange(teachers);
            context.Students.AddRange(students);
            context.SaveChanges();




            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
