using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTutorial.Model
{
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
}
