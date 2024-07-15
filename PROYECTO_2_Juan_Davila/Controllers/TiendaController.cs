using Microsoft.AspNetCore.Mvc;
using PROYECTO_2_Juan_Davila.Comunes;
using PROYECTO_2_Juan_Davila.Module;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PROYECTO_2_Juan_Davila.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        // GET: api/<TiendaController>
        [HttpGet]
        public List<Tienda> Get()
        {
            return ConexionBD.GetTiendas();
        }

        // GET api/<TiendaController>/5
        [HttpGet("{id_tienda}")]
        public Tienda Get(int id_tienda)
        {
            return ConexionBD.GetTienda(id_tienda);
        }

        // POST api/<TiendaController>
        [HttpPost]
        public void Post([FromBody] Tienda objTienda)
        {
            ConexionBD.PostTienda(objTienda);
        }

        // PUT api/<TiendaController>/5
        [HttpPut("{id_tienda}")]
        public void Put(int id_tienda, [FromBody] Tienda objTienda)
        {
            ConexionBD.PutTienda(id_tienda, objTienda);
        }

        // DELETE api/<TiendaController>/5
        [HttpDelete("{id_tienda}")]
        public void Delete(int id_tienda )
        {
            ConexionBD.DeleteTienda(id_tienda);
        }

        


    }
}
