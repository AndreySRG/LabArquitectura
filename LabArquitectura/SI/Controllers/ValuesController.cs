using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BW;
using BC;
using Microsoft.AspNetCore.Cors;

namespace SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly Gateway _gateWay;
        
        public ValuesController(Gateway gateWay)
        {
            _gateWay = gateWay;

        }
        // GET api/values
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        
        {

            List<Album> ListaAlbumes = _gateWay.ObtenerLista();

            return Ok(ListaAlbumes);

            //return new string[] { "value1", "value2" };

        }


        // GET api/values/5
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{id}")]
        public ActionResult<string> Get(int idAlbum)
        {
            Album album = new Album();
            
            album.id = idAlbum;

            Respuesta resp = new Respuesta();

             resp = _gateWay.agregarAlbum(album);

            if (resp.estado == false)
            {
                return BadRequest(resp.titulo);
            }
            else
            {
                return Ok(resp.titulo);
            }
            //_gateWay.obtenerAlbumExterno(id);


            //return "value";
        }

        // POST api/values
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
