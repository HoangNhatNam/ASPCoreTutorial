using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
}
