using SimuladorCanvas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimuladorCanvas.Controllers
{
    public class RegistroController : ApiController
    {
        private readonly RegistroData registroData;

        public RegistroController()
        {
            this.registroData = new RegistroData();
        }

        [HttpGet]
        [Route("api/registro")]
        public IHttpActionResult GetRegistro()
        {
            var registros = registroData.GetRegistros();
            return Ok(registros);
        }
    }
}
