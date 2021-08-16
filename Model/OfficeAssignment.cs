using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTutorial.Model
{
    public class OfficeAssignment
    {
        public int InstructorID { get; set; }
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}
