using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "ListarVentas")]
        public IEnumerable<Venta> listarVentas()
        {
            return VentaBussiness.ListarVentas().ToArray();
        }
        [HttpGet("{id}")]
        public IActionResult ObtenerVenta(int id)
        {
            Venta venta = VentaBussiness.ObtenerVenta(id);
            return Ok(venta);
        }
        [HttpDelete(Name = "EliminarVenta")]
        public void Delete([FromBody] int id)
        {
            VentaBussiness.EliminarVenta(id);
        }
        [HttpPut(Name = "ActualizarVenta")]
        public void Put([FromBody] Venta venta)
        {
            VentaBussiness.ActualizarVenta(venta);
        }
        [HttpPost(Name = "CrearVenta")]
        public void Post([FromBody] Venta venta)
        {
            VentaBussiness.CrearVenta(venta);
        }
    }
}
