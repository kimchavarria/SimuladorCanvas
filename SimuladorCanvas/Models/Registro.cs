using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorCanvas.Models
{
    public class Registro
    {
        public int resgistro_id {  get; set; }
        public int student_id { get; set; }
        public int course_id { get; set; }
        public string student_name { get; set; }
        public string student_email { get; set; }
    }
}