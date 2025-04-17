using CollegeSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeSystem.Contexts
{
    public class CollegeSystemDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=College;Trusted_Connection=True;TrustServerCertificate=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Teacher>(teacher =>
            {
                teacher.HasOne<Department>(t => t.Department)
                    .WithMany(d => d.Teachers)
                    .HasForeignKey(t => t.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);


                teacher.HasKey(t => t.Id);
                teacher.Property(t => t.Id)
                    .UseIdentityColumn(10, 10);

                teacher.Property(t => t.Name)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);

                teacher.Property(t => t.Salary)
                    .HasColumnType("money");


                teacher.HasOne<Course>(t => t.Course)
                    .WithMany(c => c.Teachers)
                    .HasForeignKey(t => t.CourseId);

            });

            modelBuilder.Entity<Department>(department =>
            {
                department.Property(d => d.Id)
                    .UseIdentityColumn(1, 1);

                department.Property(t => t.Name)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);

                department.Property(t => t.MgrName)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(course =>
            {
                course.HasOne<Department>(c => c.Department)
                    .WithMany(d => d.Courses)
                    .HasForeignKey(c => c.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);

                course.HasKey(c => c.Id);

                course.Property(course => course.Id)
                    .UseIdentityColumn(100, 1);

                course.Property(t => t.Name)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(student =>
            {
                student.HasOne<Department>(s => s.Department)
                    .WithMany(d => d.Students)
                    .HasForeignKey(s => s.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);

                student.Property(student => student.Id)
                    .UseIdentityColumn(10000, 1);

                student.Property(t => t.Name)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
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
