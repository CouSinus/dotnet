using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WepAPITP1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WepAPITP1.Controllers
{
    [Route("api/Devise")]
    [ApiController]
    public class DevisesController : ControllerBase
    {
        private List<Devise> listDevises;

        public List<Devise> ListDevises { get => listDevises; set => listDevises = value; }

        public DevisesController()
        {
            listDevises = new List<Devise>();
            ListDevises.Add(new Devise(1, "Dollar", 1.08));
            ListDevises.Add(new Devise(2, "Franc Suisse", 1.07));
            ListDevises.Add(new Devise(3, "Yen", 120));
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return ListDevises;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        public IActionResult GetById(int id)
        {
            Devise devise = ListDevises.FirstOrDefault(x => x.Id == id);
            return devise == null ? NotFound() : Ok(devise);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Devise devise)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ListDevises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (id != devise.Id) { return BadRequest(ModelState); }

            int index = ListDevises.FindIndex(x => x.Id == id);
            if (index < 0) { return NotFound(); }

            ListDevises[index] = devise;
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Devise devise = (from d in ListDevises where d.Id == id select d).FirstOrDefault();
            if(devise == null)
            {
                return NotFound();
            }
            ListDevises.Remove(devise);
            return Ok(devise);
        }
    }
}
