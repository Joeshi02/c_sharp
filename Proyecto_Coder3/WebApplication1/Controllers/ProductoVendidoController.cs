using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "ListarProductosVendidos")]
        public IEnumerable<ProductoVendido> listarProductosVendidos()
        {
            return ProductoVendidoBussiness.ListarProductosVendidos().ToArray();
        }
       [HttpGet("{id}")]
       public IActionResult ObtenerProductoVendido(int id)
       {
           ProductoVendido productoVendido = ProductoVendidoBussiness.ObtenerProductoVendido(id);
           return Ok(productoVendido);
       }
       [HttpDelete(Name = "EliminarProductoVendido")]
       public void Delete([FromBody] int id)
       {
           ProductoVendidoBussiness.EliminarProductoVendido(id);
       }
       
    }
}
