using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTutorial.Model
{
    public class CourseAssignment
    {
        public int CourseID { get; set; }
        public int InstructorID { get; set; }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
    }
}
