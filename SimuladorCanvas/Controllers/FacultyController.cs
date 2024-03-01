using SimuladorCanvas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimuladorCanvas.Controllers
{
    public class FacultyController : ApiController
    {
        [HttpPost]
        [Route("api/RegistrarEstudianteACurso")]
        public IHttpActionResult RegistrarEstudianteACurso(int studentId, int courseId)
        {
            try
            {
                // Instanciar la clase FacultyData
                FacultyData facultyData = new FacultyData();
                // Llamar al método RegistrarEstudianteACurso
                facultyData.RegistrarEstudianteACurso(studentId, courseId);

                // Si se ejecuta correctamente, devolver un mensaje de éxito
                return Ok("El estudiante ha sido registrado en el curso.");
            }
            catch (Exception ex)
            {
                // En caso de error, devolver un mensaje de error
                return InternalServerError(ex);
            }
        }
    }
}