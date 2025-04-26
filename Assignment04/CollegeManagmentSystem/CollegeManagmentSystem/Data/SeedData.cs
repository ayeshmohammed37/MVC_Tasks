using System;
using CollegeManagmentSystem.DbContexts;
using CollegeManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagmentSystem.Data
{
    public static class SeedData
    {
        public static void Initialize(CollegeManagmentSystemDbContext context)
        {

            if (context.Students.Any())
                return;

            //var departments = new List<Department>
            //{
            //    new Department { Name = "Computer Science", MgrName = "Dr. Smith" },
            //    new Department { Name = "Electrical Engineering", MgrName = "Dr. John" },
            //    new Department { Name = "Mechanical Engineering", MgrName = "Dr. Sarah" }
            //};
            //context.Departments.AddRange(departments);
            //context.SaveChanges();

            //var courses = new List<Course>
            //{
            //    new Course { Name = "Algorithms", Degree = 100, MinDegree = 50, DepartmentId = departments[0].Id },
            //    new Course { Name = "Data Structures", Degree = 100, MinDegree = 50, DepartmentId = departments[0].Id },
            //    new Course { Name = "Circuits", Degree = 100, MinDegree = 50, DepartmentId = departments[1].Id },
            //    new Course { Name = "Thermodynamics", Degree = 100, MinDegree = 50, DepartmentId = departments[2].Id },
            //    new Course { Name = "Machine Learning", Degree = 100, MinDegree = 50, DepartmentId = departments[0].Id }
            //};
            //context.Courses.AddRange(courses);
            //context.SaveChanges();

            //var teachers = new List<Teacher>
            //{
            //    new Teacher { Name = "Mr. A", Salary = 5000, Address = "Cairo", DepartmentId = departments[0].Id, CourseId = courses[0].Id },
            //    new Teacher { Name = "Ms. B", Salary = 5200, Address = "Giza", DepartmentId = departments[1].Id, CourseId = courses[2].Id },
            //    new Teacher { Name = "Dr. C", Salary = 6000, Address = "Alex", DepartmentId = departments[2].Id, CourseId = courses[3].Id }
            //};
            //context.Teachers.AddRange(teachers);
            //context.SaveChanges();


            //var random = new Random();
            //var gradeOptions = new[] { "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "F", "FR" };

            //var students = new List<Student>();
            //for (int i = 1; i <= 15; i++)
            //{
            //    var student = new Student
            //    {
            //        Name = $"Student {i}",
            //        Age = random.Next(18, 25),
            //        DepartmentId = departments[random.Next(departments.Count)].Id,
            //        StuCrsRess = new List<StuCrsRes>()
            //    };

            //    var assignedCourses = courses.OrderBy(x => random.Next()).Take(random.Next(2, 5)).ToList();

            //    foreach (var course in assignedCourses)
            //    {
            //        student.StuCrsRess.Add(new StuCrsRes
            //        {
            //            CourseId = course.Id,
            //            Grade = gradeOptions[random.Next(gradeOptions.Length)]
            //        });
            //    }

            //    students.Add(student);
            //}

            //context.Students.AddRange(students);
            //context.SaveChanges();


            var random = new Random();
            var grades = new[] { "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "F", "FR" };

            // Step 1: Create 5 departments
            var departments = new List<Department>();
            for (int i = 1; i <= 5; i++)
            {
                departments.Add(new Department
                {
                    Name = $"Department {i}",
                    MgrName = $"Manager {i}",
                    Teachers = new List<Teacher>(),
                    Courses = new List<Course>(),
                    Students = new List<Student>()
                });
            }

            // Step 2: Create 10 courses and assign to departments
            var courses = new List<Course>();
            for (int i = 1; i <= 10; i++)
            {
                var dept = departments[i % departments.Count]; // Even distribution

                var course = new Course
                {
                    Name = $"Course {i}",
                    Degree = 100,
                    MinDegree = 50,
                    Department = dept,
                    Teachers = new List<Teacher>(),
                    StuCrsRess = new List<StuCrsRes>()
                };

                dept.Courses.Add(course);
                courses.Add(course);
            }

            // Step 3: Create 15 teachers, assign each to a course and department
            var teachers = new List<Teacher>();
            for (int i = 1; i <= 15; i++)
            {
                var course = courses[i % courses.Count];
                var dept = course.Department;

                var teacher = new Teacher
                {
                    Name = $"Teacher {i}",
                    Salary = random.Next(4000, 8000),
                    Address = $"City {i}",
                    Course = course,
                    Department = dept
                };

                dept.Teachers.Add(teacher);
                course.Teachers.Add(teacher);
                teachers.Add(teacher);
            }

            // Step 4: Create 250 students and assign each to a department
            var students = new List<Student>();
            for (int i = 1; i <= 250; i++)
            {
                var dept = departments[i % departments.Count];

                var student = new Student
                {
                    Name = $"Student {i}",
                    Age = random.Next(18, 22),
                    Department = dept,
                    StuCrsRess = new List<StuCrsRes>()
                };

                // Enroll in 3 random courses from the same department
                var deptCourses = dept.Courses.OrderBy(_ => random.Next()).Take(3).ToList();
                foreach (var course in deptCourses)
                {
                    var scr = new StuCrsRes
                    {
                        Grade = grades[random.Next(grades.Length)],
                        Course = course,
                        Student = student
                    };

                    student.StuCrsRess.Add(scr);
                    course.StuCrsRess.Add(scr);
                }

                dept.Students.Add(student);
                students.Add(student);
            }

            context.Departments.AddRange(departments);
            context.Courses.AddRange(courses);
            context.Teachers.AddRange(teachers);
            context.Students.AddRange(students);
            context.SaveChanges();

        }
    }
}