using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SimuladorCanvas.Models
{
    public class Course
    {
        public int course_id {  get; set; }
        public int faculty_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int credits {  get; set; }
        public DateTime initialDate { get; set; }
        public DateTime finalDate { get; set; }
    }
}
