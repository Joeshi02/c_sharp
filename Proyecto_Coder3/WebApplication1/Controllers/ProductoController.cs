using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "ListarProductos")]
        public IEnumerable<Producto> listarProductos()
        {
            return ProductoBussiness.ListarProductos().ToArray();
        }
        [HttpGet("{id}")]
        public IActionResult ObtenerProducto(int id)
        {
            Producto producto = ProductoBussiness.ObtenerProducto(id);
            return Ok(producto);
        }
        [HttpDelete(Name = "EliminarProducto")]
        public void Delete([FromBody] int id)
        {
            ProductoBussiness.EliminarProducto(id);
        }
        [HttpPut (Name ="ActualizarProducto")]
        public void Put([FromBody] Producto producto)
        {
            ProductoBussiness.ActualizarProducto(producto);
        }
        [HttpPost (Name = "CrearProducto")]
        public void Post([FromBody] Producto producto)
        {
            ProductoBussiness.CrearProducto(producto);
        }
        
    }
}
