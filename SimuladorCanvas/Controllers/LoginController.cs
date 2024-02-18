using SimuladorCanvas.Data; 
using SimuladorCanvas.Models; 
using System; 
using System.Collections.Generic; 
using System.Data.SqlClient; 
using System.Linq; 
using System.Net; 
using System.Net.Http;
using System.Web.Http;

namespace SimuladorCanvas.Controllers
{
    public class LoginController : ApiController
    {
        // Campo readonly donde se almacena una instancia de la clase LoginData para el acceso a datos
        private readonly LoginData loginData;

        // Constructor de la clase LoginController
        public LoginController() 
        {
            // Inicializa el campo loginData con una nueva instancia de LoginData
            this.loginData = new LoginData();
        }
        // Atributo que indica que el método responde a solicitudes HTTP POST
        [HttpPost]
        // Atributo que especifica la ruta de la solicitud para acceder a este método
        [Route("api/login")]
        // Método para el inicio de sesión, toma un objeto Login como argumento y devuelve un IHttpActionResult
        public IHttpActionResult Login(Login model) 
        {
            if (!ModelState.IsValid) // Verifica si el modelo recibido no es válido
            {
                return BadRequest(ModelState); // Devuelve un error BadRequest con el estado del modelo
            }

            // Llama al método Login de la instancia de LoginData para intentar el inicio de sesión
            bool success = loginData.Login(model.Username, model.Password, model.UserType);

            if (success) // Verifica si el login fue exitoso
            {
                return Ok(new { message = "Login successful", userType = model.UserType }); // Devuelve un Ok con un objeto anónimo que contiene un mensaje de éxito y el tipo de usuario
            }
            else
            {
                return BadRequest("Login failed"); // Devuelve un error BadRequest indicando que el login falló
            }
        }
    }
}
