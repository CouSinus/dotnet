using Microsoft.AspNetCore.Mvc;
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
        public Devise GetById(int id)
        {
            return ListDevises.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
