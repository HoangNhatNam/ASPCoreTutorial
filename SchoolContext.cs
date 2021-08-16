using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
                @"Server=LAPTOP-N65FQACU\SQLEXPRESS;Database=SchoolDB1;Trusted_Connection=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>()
                .ToTable("Course")
                .HasKey(c => c.CourseID);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentID)
                .HasPrincipalKey(d => d.DepartmentID);

            modelBuilder.Entity<Enrollment>()
                .ToTable("Enrollment")
                .HasKey(e => e.EnrollmentID);

            modelBuilder.Entity<Instructor>()
                .ToTable("Instructor")
                .HasKey(i => i.ID);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.OfficeAssignment)
                .WithOne(o => o.Instructor)
                .HasForeignKey<OfficeAssignment>(i => i.InstructorID);

            modelBuilder.Entity<OfficeAssignment>()
                .ToTable("OfficeAssignment")
                .HasKey(o => o.InstructorID);

            modelBuilder.Entity<Student>(
                eb =>
                {
                    eb.ToTable("Student").HasKey(student => student.ID);
                    eb.Ignore(student => student.FullName);
                });

            modelBuilder.Entity<CourseAssignment>()
                .ToTable("CourseAssignment")
                .HasKey(c => new { c.CourseID, c.InstructorID });

            modelBuilder.Entity<Department>()
                .ToTable("Department")
                .HasKey(d => d.DepartmentID);
        }
    }
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<CourseAssignment> CourseAssignment { get; set; }
        public Department Department { get; set; }

    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public int? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
    public class Instructor
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }

        public OfficeAssignment OfficeAssignment { get; set; }
        public List<CourseAssignment> CourseAssignment { get; set; }
    }
    public class OfficeAssignment
    {
        public int InstructorID { get; set; }
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public List<Enrollment> Enrollments { get; set; }

        [NotMapped]
        public string FullName => LastName.Trim() + " "+ FirstMidName.Trim();
    }
    public class CourseAssignment
    {
        public int CourseID { get; set; }
        public int InstructorID { get; set; }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
    }
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int InstructorID { get; set; }

        public Instructor Instructor { get; set; }
        public List<Course> Courses { get; set; }
    }
    public class DepartmentModel
    {
        public int InstructorCount { get; set; }
        public string Name { get; set; }

        public int CourseCount { get; set; }
        public string FirstMidName { get; set; }
        
    }
    public class CourseModel
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<CourseAssignment> CourseAssignment { get; set; }
        public Department Department { get; set; }


        public int InstructorCount { get; set; }

        public int EnrollmentCount { get; set; }
    }
    public class StudentModel
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        
        public List<Enrollment> Enrollments { get; set; }
        public int? Grade { get; set; }
        public int GradeCount { get; set; }
        public int EnrollmentCount { get; set; }
    }
    
    public class EnrollmentModel
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public int? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
