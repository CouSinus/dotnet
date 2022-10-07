using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APISeries.Models.EntityFramework;
using APISeries.Models.DataManager;
using APISeries.Models.Repository;

namespace APISeries.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly string ERROR_ID_NOT_FOUND = "id Utilisateur non trouvé";

        private readonly IDataRepository<Utilisateur> dataRepository;

        public UtilisateursController(IDataRepository<Utilisateur> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            return dataRepository.GetAll();
        }

        // GET: api/Utilisateurs/5
        [HttpGet]
        [ActionName("id")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateurById(int id)
        {
            var utilisateur = dataRepository.GetById(id);
            //var utilisateur = await _context.Utilisateurs.Include(u => u.NotesUtilisateur).SingleOrDefaultAsync(m => m.UtilisateurId == id);
            if (utilisateur == null)
            {
                return NotFound(ERROR_ID_NOT_FOUND);
            }
            return utilisateur;
        }

        [HttpGet]
        [ActionName("email")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateurByEmail(string email)
        {
            var utilisateur = await dataRepository.GetByStringAsync(email);
            if (utilisateur == null)
            {
                return NotFound();
            }
            return utilisateur;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [ActionName("id")]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.UtilisateurId)
            {
                return BadRequest();
            }
            var userToUpdate = dataRepository.GetById(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            dataRepository.Update(userToUpdate.Value, utilisateur);
            return NoContent();
        }

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
        {
            dataRepository.Add(utilisateur);
            return CreatedAtAction("GetById", new { id = utilisateur.UtilisateurId }, utilisateur);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Utilisateur>> DeleteUtilisateur(int id)
        {
            var utilisateur = dataRepository.GetById(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            dataRepository.Delete(utilisateur.Value);
            return utilisateur;
        }

        /*private bool UtilisateurExists(int id)
        {
            return _context.Utilisateur.Any(e => e.UtilisateurId == id);
        }*/
    }
}
