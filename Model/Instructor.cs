using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTutorial.Model
{
    public class Instructor
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }

        public OfficeAssignment OfficeAssignment { get; set; }
        public List<CourseAssignment> CourseAssignment { get; set; }
    }
}
