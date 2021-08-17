using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using ASPCoreTutorial.Model;
using Microsoft.EntityFrameworkCore;


namespace ASPCoreTutorial
{
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignment { get; set; }
        public DbSet<CourseAssignment> CourseAssignment { get; set; }
        public DbSet<Department> Department { get; set; }

        public SchoolContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=LAPTOP-N65FQACU\SQLEXPRESS;Database=SchoolDB2;Trusted_Connection=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>(
                eb =>
                {
                    eb.ToTable("Course").HasKey(x => x.CourseID);
                    eb.HasOne(x => x.Department).WithMany(d => d.Courses).HasForeignKey(c => c.DepartmentID).HasPrincipalKey(d => d.DepartmentID);
                    eb.Property(x => x.CourseID).HasColumnName("course_id");
                    eb.Property(x => x.Title).HasColumnName("title");
                    eb.Property(x => x.Credits).HasColumnName("credits");
                    eb.Property(x => x.DepartmentID).HasColumnName("department_id");
                });

            modelBuilder.Entity<Enrollment>(
                eb =>
                {
                    eb.ToTable("Enrollment").HasKey(x => x.EnrollmentID);
                    eb.HasOne(x => x.Course).WithMany(c => c.Enrollments).HasForeignKey(e => e.CourseID).HasPrincipalKey(c => c.CourseID);
                    eb.HasOne(x => x.Student).WithMany(s => s.Enrollments).HasForeignKey(e => e.StudentID).HasPrincipalKey(s => s.ID);
                    eb.Property(x => x.EnrollmentID).HasColumnName("enrollment_id");
                    eb.Property(x => x.CourseID).HasColumnName("course_id");
                    eb.Property(x => x.StudentID).HasColumnName("student_id");
                    eb.Property(x => x.Grade).HasColumnName("grade");
                });

            modelBuilder.Entity<Instructor>(
                eb =>
                {
                    eb.ToTable("Instructor").HasKey(x => x.ID);
                    eb.HasOne(x => x.OfficeAssignment).WithOne(o => o.Instructor).HasForeignKey<OfficeAssignment>(i => i.InstructorID);
                    eb.Property(x => x.ID).HasColumnName("instructor_id");
                    eb.Property(x => x.LastName).HasColumnName("last_name");
                    eb.Property(x => x.FirstMidName).HasColumnName("first_mid_name");
                    eb.Property(x => x.HireDate).HasColumnName("hire_date");
                });

            modelBuilder.Entity<OfficeAssignment>(
                eb =>
                {
                    eb.ToTable("OfficeAssignment").HasKey(x => x.InstructorID);
                    eb.Property(x => x.InstructorID).HasColumnName("instructor_id");
                    eb.Property(x => x.Location).HasColumnName("location");
                });


            modelBuilder.Entity<Student>(
                eb =>
                {
                    eb.ToTable("Student").HasKey(x => x.ID);
                    eb.Property(x => x.ID).HasColumnName("student_id");
                    eb.Property(x => x.LastName).HasColumnName("last_name");
                    eb.Property(x => x.FirstMidName).HasColumnName("first_mid_name");
                    eb.Property(x => x.EnrollmentDate).HasColumnName("enrollment_date");
                });

            modelBuilder.Entity<CourseAssignment>(
                eb => {
                    eb.ToTable("CourseAssignment").HasKey(x => new { x.CourseID, x.InstructorID });
                    eb.HasOne(x => x.Instructor).WithMany(i => i.CourseAssignment).HasForeignKey(c => c.InstructorID).HasPrincipalKey(i => i.ID);
                    eb.HasOne(x => x.Course).WithMany(c => c.CourseAssignment).HasForeignKey(c => c.CourseID).HasPrincipalKey(c => c.CourseID);
                    eb.Property(x => x.CourseID).HasColumnName("course_id");
                    eb.Property(x => x.InstructorID).HasColumnName("instructor_id");
                });

            modelBuilder.Entity<Department>(
                eb => {
                    eb.ToTable("Department").HasKey(x => x.DepartmentID);
                    eb.HasOne(x => x.Instructor).WithMany().HasForeignKey(d => d.InstructorID);
                    eb.Property(x => x.DepartmentID).HasColumnName("department_id");
                    eb.Property(x => x.Name).HasColumnName("name");
                    eb.Property(x => x.Budget).HasColumnName("budget");
                    eb.Property(x => x.StartDate).HasColumnName("start_date");
                    eb.Property(x => x.InstructorID).HasColumnName("instructor_id");
                });

            //modelBuilder.Entity<Student>().HasData(
            //    new { ID = 1, LastName = "Hoang", FirstMidName = "Nhat Nam", EnrollmentDate = DateTime.Now },
            //    new { ID = 2, LastName = "Thi", FirstMidName = "Nhat Minh", EnrollmentDate = DateTime.Now },
            //    new { ID = 3, LastName = "Ngo", FirstMidName = "Viet Hung", EnrollmentDate = DateTime.Now },
            //    new { ID = 4, LastName = "Luu", FirstMidName = "Duc Thai", EnrollmentDate = DateTime.Now }
            //    );
            //modelBuilder.Entity<Enrollment>().HasData(
            //    new { EnrollmentID = 1, CourseID = 2, StudentID = 1, Grade = 2 },
            //    new { EnrollmentID = 2, CourseID = 3, StudentID = 1, Grade = 1 },
            //    new { EnrollmentID = 3, CourseID = 4, StudentID = 2, Grade = 3 },
            //    new { EnrollmentID = 4, CourseID = 5, StudentID = 2, Grade = 2 },
            //    new { EnrollmentID = 5, CourseID = 1, StudentID = 3, Grade = 4 },
            //    new { EnrollmentID = 6, CourseID = 2, StudentID = 3, Grade = 2 },
            //    new { EnrollmentID = 7, CourseID = 4, StudentID = 3, Grade = 4 }
            //);
            //modelBuilder.Entity<Course>().HasData(
            //    new { CourseID = 1, Title = "Thiet ke mau", Credits = 2000000, DepartmentID = 7 },
            //    new { CourseID = 2, Title = "Giao duc the chat", Credits = 3000000, DepartmentID = 2 },
            //    new { CourseID = 3, Title = "Quoc phong", Credits = 4000000, DepartmentID = 3 },
            //    new { CourseID = 4, Title = "Thiet ke web", Credits = 5000000, DepartmentID = 7 },
            //    new { CourseID = 5, Title = "Quan tri co so du lieu", Credits = 5000000, DepartmentID = 7 }
            //);
            //modelBuilder.Entity<CourseAssignment>().HasData(
            //    new { CourseID = 1, InstructorID = 2 },
            //    new { CourseID = 5, InstructorID = 1 },
            //    new { CourseID = 3, InstructorID = 2 },
            //    new { CourseID = 2, InstructorID = 3 },
            //    new { CourseID = 4, InstructorID = 1 }
            //);
            //modelBuilder.Entity<Instructor>().HasData(
            //    new { ID = 1, LastName = "Thach", FirstMidName = "Son Kim Quang", HireDate = DateTime.Now },
            //    new { ID = 2, LastName = "Vo", FirstMidName = "Ngoc Tam", HireDate = DateTime.Now },
            //    new { ID = 3, LastName = "Nguyen", FirstMidName = "Van A", HireDate = DateTime.Now },
            //    new { ID = 4, LastName = "Chi", FirstMidName = "Thoai", HireDate = DateTime.Now }
            //);
            //modelBuilder.Entity<Department>().HasData(
            //    new { DepartmentID = 1, Name = "English", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 1 },
            //    new { DepartmentID = 2, Name = "Computer Science", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 2 },
            //    new { DepartmentID = 3, Name = "Scince", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 3 },
            //    new { DepartmentID = 4, Name = "Social Studies", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 1 },
            //    new { DepartmentID = 5, Name = "Theology", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 2 },
            //    new { DepartmentID = 6, Name = "Mathematics", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 3 },
            //    new { DepartmentID = 7, Name = "IT", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 1 }
            //);
        }
    }

}
