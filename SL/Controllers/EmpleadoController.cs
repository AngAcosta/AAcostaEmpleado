using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace SL.Controllers
{
    public class EmpleadoController : Controller
    {
        [EnableCors("API")]
        [HttpGet]
        [Route("api/Empleado/GetAll")]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            ML.Result result = BL.Empleado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
            return View();
        }

        [EnableCors("API")]
        [HttpPost]
        [Route("api/Empleado/Add")]
        public ActionResult Add([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [EnableCors("API")]
        [HttpPost]
        [Route("api/Empleado/Update")]
        public ActionResult Update([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [EnableCors("API")]
        [HttpGet]
        [Route("api/Empleado/Delete/{idEmpleado}")]
        public ActionResult Delete(int idEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(idEmpleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [EnableCors("API")]
        [HttpGet]
        [Route("api/Empleado/GetById/{idEmpleado}")]
        public ActionResult GetById(int idEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(idEmpleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [EnableCors("API")]
        [HttpGet]
        [Route("api/Estado/GetAllEstado")]
        public ActionResult GetAllEstado()
        {
            ML.Empleado empleado = new ML.Empleado();
            ML.Result result = BL.Estado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
            return View();
        }
    }
}