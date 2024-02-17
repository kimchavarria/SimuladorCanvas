using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorCanvas.Models
{
    public class Faculty
    {
        public int faculty_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public DateTime dob { get; set; }
        public string number { get; set; }
        public string email { get; set; }
        public string department { get; set; }
        public string password { get; set; }
    }
}
