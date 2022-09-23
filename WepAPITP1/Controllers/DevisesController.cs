using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WepAPITP1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WepAPITP1.Controllers
{
    [Route("api/devise")]
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

        /// <summary>
        /// Get all currencies
        /// </summary>
        /// <returns>List of currencies</returns>
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return ListDevises;
        }

        /// <summary>
        /// Get a single currency
        /// </summary>
        /// <param name="id">Currency id</param>
        /// <returns>HttpResponse</returns>
        /// <response code ="200">Found a currency</response>
        /// <response code ="404">No currency found</response>
        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        [ProducesResponseType(typeof(Devise), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            Devise devise = ListDevises.FirstOrDefault(x => x.Id == id);
            return devise == null ? NotFound() : Ok(devise);
        }

        /// <summary>
        /// Save a new currency
        /// </summary>
        /// <param name="devise">Currency</param>
        /// <returns>HttpResponse</returns>
        /// <response code ="200">Currency saved</response>
        /// <response code ="400">Invalid format of currency</response>
        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(typeof(Devise), 200)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Devise devise)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ListDevises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        /// <summary>
        /// Edit a currency
        /// </summary>
        /// <param name="id">Currency id</param>
        /// <param name="devise">Currency</param>
        /// <returns>HttpResponse</returns>
        /// <response code ="200">Currency saved</response>
        /// <response code ="400">Invalid format of currency</response>
        /// <response code ="404">Currency not found</response>
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Devise), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (id != devise.Id) { return BadRequest(ModelState); }

            int index = ListDevises.FindIndex(x => x.Id == id);
            if (index < 0) { return NotFound(); }

            ListDevises[index] = devise;
            return NoContent();
        }

        /// <summary>
        /// Delete a currency
        /// </summary>
        /// <param name="id">Currency id</param>
        /// <returns>HttpResponse</returns>
        /// <response code ="200">Currency saved</response>
        /// <response code ="404">Currency not found</response>
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Devise), 200)]
        [ProducesResponseType(404)]
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
