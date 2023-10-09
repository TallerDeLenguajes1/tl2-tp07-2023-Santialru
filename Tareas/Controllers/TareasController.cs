using Microsoft.AspNetCore.Mvc;
using webapi;

namespace elmanejo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManejoController : ControllerBase
    {
        private Manejo manejo;
        private readonly ILogger<ManejoController> _logger;

        public ManejoController(ILogger<ManejoController> logger)
        {
            _logger=logger;
            manejo = Manejo.Instance();
        }

        [HttpPost]
        [Route("CrearTarea")]
        public ActionResult CrearTarea()
        {
            int cantT = manejo.ListaTarea.Count;
            manejo.CrearTarea();
            manejo.AccesoATareas.Guardar(manejo.ListaTarea);
            if (manejo.ListaTarea.Count == cantT+1)
            {
                return Ok("Tarea agregada correctamente");
            }else
            {
                return StatusCode(500, "no se puudo cargar el pedido");
            }
        }

        [HttpGet]
        [Route("ObtenerTareaById/{id}")]
        public IActionResult ObtenerTareaById(int id)
        {
            Tarea TareaBuscada = manejo.ListaTarea.FirstOrDefault(tarea => tarea.Id==id);
            if (TareaBuscada !=null)
            {
                return Ok(TareaBuscada);
            }else
            {
                return NotFound("Tarea no encontrado");
            }
        }

        [HttpPut]
        [Route("ActualizarTarea/{id}/{titulo}/{descripcion}/{estado}")]
        public IActionResult ActualizarTarea(int id,string titulo,string descripcion, string estado)
        {
            Tarea TareaBuscada = manejo.ListaTarea.FirstOrDefault(tarea => tarea.Id==id);
            if (TareaBuscada !=null)
            {
                manejo.ActualizarTarea( id, titulo, descripcion, estado, TareaBuscada);
                return Ok("tarea actualizada correctamente"+ TareaBuscada);
            }else
            {
                return NotFound("Tarea no encontrado");
            }

        }
        [HttpDelete]
        [Route("EliminarTarea/{id}")]
        public ActionResult EliminarTarea(int id)
        {
            Tarea TareaBuscada = manejo.ListaTarea.FirstOrDefault(tarea => tarea.Id==id);
            if (TareaBuscada !=null)
            {
                manejo.ListaTarea.Remove(TareaBuscada);
                manejo.AccesoATareas.Guardar(manejo.ListaTarea);
                return Ok("se elimino correctamente la tarea:"+TareaBuscada);
            }else
            {
                return NotFound("Tarea no encontrado");
            }

        }

        [HttpGet]
        [Route("ListarTodasTareas")]
        public ActionResult ListarTodasTareas() 
        {
            foreach (var item in manejo.ListaTarea)
            {
                item.ListarTarea();
            }
            return Ok("tareas listadas correctamente");
        }
        
        
        [HttpGet]
        [Route("ListarTareasCompletadas")]
        public ActionResult ListarTareasCompletadas() 
        {
            foreach (var item in manejo.ListaTarea)
            {
                if (item.Estado=="Completada")
                {
                    item.ListarTarea();
                }
            }
            return Ok("tareas completadas listadas correctamente");
        }

    }
}