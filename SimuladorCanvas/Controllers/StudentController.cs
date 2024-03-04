using SimuladorCanvas.Data;
using SimuladorCanvas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimuladorCanvas.Controllers
{
    public class StudentController : ApiController
    {
        private readonly StudentData studentData;

        public StudentController()
        {
            this.studentData = new StudentData();
        }

        [HttpGet]
        [Route("api/students")]
        public IHttpActionResult GetStudentDetails()
        {
            List<Student> students = studentData.GetStudentDetails();
            return Ok(students);
        }
    }
}