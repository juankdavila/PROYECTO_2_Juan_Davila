using Microsoft.AspNetCore.Mvc;
using PROYECTO_2_Juan_Davila.Comunes;
using PROYECTO_2_Juan_Davila.Module;
using System.Xml.Schema;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PROYECTO_2_Juan_Davila.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        // GET: api/<ProductosController>
        [HttpGet]
        public List<Producto> Get()
        {
            return ConexionBD.GetProductos();
        }

        // GET api/<ProductosController>/5
        [HttpGet("{codigo}")]
        public Producto Get(string codigo)
        {
            return ConexionBD.GetProducto(codigo);
        }

        // POST api/<ProductosController>
        [HttpPost]
        public void Post([FromBody] Producto objProducto)
        {
            ConexionBD.PostProducto(objProducto);
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{codigo}")]
        public void Put(string codigo, [FromBody] Producto objProducto)
        {
            ConexionBD.PutProducto(codigo, objProducto);
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{codigo}")]
        public void Delete(string codigo)
        {
            ConexionBD.DeleteProducto(codigo);
        }

        [HttpGet("{codigo}/{cedula}")]
        public decimal GetPrecioPromocion(string codigo, string cedula)
        {
           
            Producto objProducto = new Producto();
            return objProducto.precio;

        }


    }
}
