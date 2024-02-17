using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SimuladorCanvas.Models
{
    public class Grade
    {
        public int grade_id { get; set; }
        public int faculty_id { get; set; }
        public int student_id { get; set; }
        public int course_id { get; set; }
        public int grade { get; set; }
        public DateTime date { get; set; }
        public bool status { get; set; }
    }
}