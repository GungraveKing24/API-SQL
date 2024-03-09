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
        /// Seleccionar todos buscando por ID de cliente 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("GetAll/{id}")]
        public IActionResult Get(int id)
        {
            var ListaAll = (from client in _RestauranteContext.Clientes
                            join pedido in _RestauranteContext.Pedidos
                            on client.clienteId equals pedido.clienteId
                            where client.clienteId == id
                            select new
                            {
                                client,
                                pedido
                            }).FirstOrDefault();

            if (ListaAll == null)
            {
                return NotFound();
            }
            return Ok(ListaAll);
        }


        [HttpGet]
        [Route("GetAllUnaTabla")]
        public IActionResult GetAllUnaTabla(int id)
        {
            List<clientes> ListaAll = (from client in _RestauranteContext.Clientes
                            where client.clienteId == id
                            select client).ToList();

            if (ListaAll == null)
            {
                return NotFound();
            }
            return Ok(ListaAll);
        }

        [HttpGet]
        [Route("GetAllCliente")]
        public IActionResult GetCli()
        {
            List<clientes> listadoClientes = (from e in _RestauranteContext.Clientes
                                              select e).ToList();
            if (listadoClientes.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoClientes);
        }

    }
}
