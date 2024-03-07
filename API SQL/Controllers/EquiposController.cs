using API_SQL.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_SQL.Models;

namespace API_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly EquiposContext _equiposContext;

        public EquiposController(EquiposContext equiposContexto)
        {
            _equiposContext = equiposContexto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Filtro"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("FindFiltro/{Filtro}")]

        public IActionResult GetPorfiltro(string Filtro)
        {
            equipos? equipo = (from e in _equiposContext.Equipos
                               where e.descripcion.Contains(Filtro)
                               select e).FirstOrDefault();

            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(equipo);
        }
    }
}
