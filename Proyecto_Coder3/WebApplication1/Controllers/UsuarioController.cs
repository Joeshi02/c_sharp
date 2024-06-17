using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "ListarUsuarios")]
        public IEnumerable<Usuario> listarUsuarios()
        {
            return UsuarioBussiness.ListarUsuario().ToArray();
        }
        [HttpGet("{id}")]
        public IActionResult ObtenerUsuario(int id)
        {
            Usuario usuario = UsuarioBussiness.ObtenerUsuario(id);
            return Ok(usuario);
        }
        [HttpDelete(Name = "EliminarUsuario")]
        public void Delete([FromBody] int id)
        {
            UsuarioBussiness.EliminarUsuario(id);
        }
        [HttpPut(Name = "ActualizarUsuario")]
        public void Put([FromBody] Usuario usuario)
        {
            UsuarioBussiness.ActualizarUsuario(usuario);
        }
        [HttpPost(Name = "CrearUsuario")]
        public void Post([FromBody] Usuario usuario)
        {
            UsuarioBussiness.CrearUsuario(usuario);
        }
    }
}
