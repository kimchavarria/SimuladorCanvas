using SimuladorCanvas.Data;
using SimuladorCanvas.Models;
using System.Web.Http;

namespace SimuladorCanvas.Controllers
{
    public class FacultyController : ApiController
    {
        private readonly FacultyData facultyData;

        public FacultyController()
        {
            this.facultyData = new FacultyData();
        }

        [HttpPost]
        [Route("api/faculty/register")]
        public IHttpActionResult RegisterStudentToCourse(Registro request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool success = facultyData.RegisterStudentToCourse(request.student_id, request.course_id);

            if (success)
            {
                return Ok(new { message = "Student registered successfully to the course" });
            }
            else
            {
                return BadRequest("Failed to register student to the course");
            }
        }
    }
}
