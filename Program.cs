using System;
using System.Collections.Generic;
using System.Linq;
using ASPCoreTutorial.Model;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreTutorial
{
    internal class Program
    {
        private static void Main()
        {
            //Query1();
            //Query2();
            //Query6();
            //Query8();
            //Query9();
            //Query10();
            //Query11();
            //Query12();
            
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Query1()
        {
            using var db = new SchoolContext();

            var list = db.Instructor
                .Include(a => a.OfficeAssignment)
                .ToList();

            Console.WriteLine("1. Get all instructor with Location in OfficeAssignment");
            foreach (var item in list)
            {
                Console.WriteLine(item.FirstMidName + " " + item.OfficeAssignment.Location);
            }
        }
        private static void Query2()
        {
            using var db = new SchoolContext();
            var result32 = db.Department
                .Select(s => s.Instructor.FirstMidName + s.Name);
            Console.WriteLine("2. Get all Department + Instructor (FirstName + LastName)");
            Show(result32);
        }
        private static void Query6()
        {
            using var db = new SchoolContext();
            var result62 = db.Student
                .Include(i => i.Enrollments)
                .ThenInclude(a => a.Course)
                .ThenInclude(a => a.Department)
                .ToList();
            Console.WriteLine("6. Get all Student + Enrollment + CourseName + DepartmentName");
            foreach (var student in result62)
            {
                Console.WriteLine(student.FullName);
                foreach (var enrollment in student.Enrollments)
                {
                    Console.WriteLine("{0}\t{1}\t{2}" , enrollment.Course.Title, enrollment.Grade, enrollment.Course.Department.Name);
                }
            }
        }
        private static void Query8()
        {
            using var db = new SchoolContext();
            var result82 = db.Student
                .Select(x => new StudentModel()
                {
                    FirstMidName = x.FirstMidName,
                    EnrollmentCount = x.Enrollments.Count(),
                });
            Console.WriteLine("8. Get all student + count enrollment course");
            foreach (var item in result82)
            {
                Console.WriteLine(item.FirstMidName + item.EnrollmentCount);
            }
        }
        private static void Query9()
        {
            using var db = new SchoolContext();
            var result102 = db.Department
                .Include(a => a.Instructor)
                //.GroupBy(a => new { a.InstructorID, a.Instructor.FirstMidName })
                .Select(x => new DepartmentModel()
                {
                    FirstMidName = x.Instructor.FirstMidName,
                });
            Console.WriteLine("9. Count instructor for each department");
            foreach (var item in result102)
            {
                Console.WriteLine(item.FirstMidName + item.InstructorCount);
            }
        }
        private static void Query10()
        {
            using var db = new SchoolContext();
            var result1002 = db.Course
                .Include(a => a.Department)
                .GroupBy(a => new { a.DepartmentID, a.Department.Name })
                .Select(x => new DepartmentModel()
                {
                    Name = x.Key.Name,
                    CourseCount = x.Count(),
                });
            Console.WriteLine("10. Count course for each department");
            foreach (var item in result1002)
            {
                Console.WriteLine(item.Name + item.CourseCount);
            }
        }
        private static void Query11()
        {
            using var db = new SchoolContext();
            IQueryable<DepartmentModel> result112 = db.Department
                .Include(a => a.Instructor)
                .GroupBy(a => new { a.InstructorID, a.Instructor.FirstMidName })
                .Select(x => new DepartmentModel()
                {
                    FirstMidName = x.Key.FirstMidName,
                    InstructorCount = x.Count(),
                });
            Console.WriteLine("11. Get all deparment, numm of instructor/course/(student)");
            foreach (var item in result112)
            {
                Console.WriteLine(item.FirstMidName + item.InstructorCount);
            }
        }
        //private static void Query12()
        //{
        //    using var db = new SchoolContext();
        //    var result122 = db.Enrollment.GroupBy(x => x.Grade)
        //        .Select(x => new StudentModel()
        //        {
        //            Grade = x.Key,
        //            GradeCount = x.Count(),
        //        });
        //    Console.WriteLine("12. Count student for each grade");
        //    foreach (var item in result122)
        //    {
        //        Console.WriteLine(item.Grade + item.GradeCount);
        //    }
        //}
        private static void CreateDatabase()
        {
            using var db = new SchoolContext();
            db.Database.EnsureCreated();
        }
        private static void CreateWithMigra()
        {
            /*
            dotnet ef migrations add MigrationName
            dotnet ef migrations list
            dotnet ef migrations remove

            dotnet ef database update MigrationName
            dotnet database drop -f
             */
        }

        //private static void AddNewInstructor()
        //{
        //    using (var context = new SchoolContext())
        //    {
        //        var instructor = context.Instructor.Include(x => x.OfficeAssignment).First();
        //        var officeAssignment = new OfficeAssignment {Location = "ABC"};

        //        instructor.OfficeAssignment.Add(officeAssignment);
        //        context.SaveChanges();
        //    }
        //}
        private static void AddNewDepartment()
        {
            using (var context = new SchoolContext())
            {
                var department = new Department
                {
                    Name = "Test",
                    Budget = 200000,
                    StartDate = DateTime.Now,
                    Courses = new List<Course>
                    {
                        new Course { Title = "-Test1", Credits = 12000},
                        new Course { Title = "-Test2", Credits = 12000},
                        new Course { Title = "-Test3", Credits = 12000 }
                    }
                };

                context.Department.Add(department);
                context.SaveChanges();
            }
        }
        private static void AddNewStudent()
        {
            using (var context = new SchoolContext())
            {
                var student = new Student
                {
                    LastName = "Test",
                    FirstMidName = "Test",
                    EnrollmentDate = DateTime.Now
                };
                context.Student.Add(student);
                context.SaveChanges();
            }
        }
        private static void UpdateStudent(int id)
        {
            using (var context = new SchoolContext())
            {
                var student = context.Student.First(x => x.ID == id);
                student.LastName = "Test";
                student.FirstMidName = "Test";
                context.SaveChanges();
            }
        }
        private static void DeleteStudent(int id)
        {
            using (var context = new SchoolContext())
            {
                var student = context.Student.First(x => x.ID == id);
                context.Student.Remove(student);
                context.SaveChanges();
            }
        }
        private static void RemoveDepartment()
        {
            using (var context = new SchoolContext())
            {
                var department = context.Department.Include(x => x.Courses).First();
                var courses = department.Courses.First();

                department.Courses.Remove(courses);
                context.SaveChanges();
            }
        }
        public static void Show(IQueryable<string> result)
        {
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
