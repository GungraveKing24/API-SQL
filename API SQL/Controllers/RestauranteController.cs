using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using API_SQL.models;

namespace API_SQL.Controllers
{
    public class RestauranteController : ControllerBase
    {
        private readonly RestauranteContext _RestauranteContext;

        public RestauranteController(RestauranteContext restauranteContext)
        {
            _RestauranteContext = restauranteContext;
        }


        /// <summary>
        /// Seleccionar todos buscando por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("GetAll/{id}")]

        public IActionResult Get(int id)
        {
            var ListaAll = (from c in _RestauranteContext.Clientes
                            join p in _RestauranteContext.Pedidos
                            on c.clienteId equals p.clienteId
                            where c.clienteId == id
                            select new
                            { c, p
                            }).FirstOrDefault();

            if (ListaAll == null)
            {
                return NotFound();
            }
            return Ok(ListaAll);
        }

        
    }
}
