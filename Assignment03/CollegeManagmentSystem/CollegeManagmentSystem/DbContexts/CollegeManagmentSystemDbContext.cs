using CollegeManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagmentSystem.DbContexts
{
    public class CollegeManagmentSystemDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CollegeManagmentSystem;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>(teacher =>
            {
                teacher.HasOne<Department>(t => t.Department)
                    .WithMany(d => d.Teachers)
                    .HasForeignKey(t => t.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);


                teacher.HasOne<Course>(t => t.Course)
                    .WithMany(c => c.Teachers)
                    .HasForeignKey(t => t.CourseId);

            });

            modelBuilder.Entity<Course>(course =>
            {
                course.HasOne<Department>(c => c.Department)
                    .WithMany(d => d.Courses)
                    .HasForeignKey(c => c.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);

            });


            modelBuilder.Entity<Student>(student =>
            {
                student.HasOne<Department>(s => s.Department)
                    .WithMany(d => d.Students)
                    .HasForeignKey(s => s.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);

            });


            modelBuilder.Entity<StuCrsRes>(scr =>
            {
                scr.HasKey(scr => new { scr.StudentId, scr.CourseId });

                scr.HasOne<Student>(sc => sc.Student)
                    .WithMany(s => s.StuCrsRess)
                    .HasForeignKey(sc => sc.StudentId);

                scr.HasOne<Course>(sc => sc.Course)
                    .WithMany(c => c.StuCrsRess)
                    .HasForeignKey(sc => sc.CourseId);
            });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StuCrsRes> StuCrsRess { get; set; }

    }
}
