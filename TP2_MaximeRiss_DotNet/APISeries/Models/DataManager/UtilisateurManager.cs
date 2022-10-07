using APISeries.Models.EntityFramework;
using APISeries.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISeries.Models.DataManager
{
    public class UtilisateurManager : IDataRepository<Utilisateur>
    {
        readonly SeriesDBContext? seriesDbContext;
        public UtilisateurManager() { }
        public UtilisateurManager(SeriesDBContext context)
        {
            seriesDbContext = context;
        }
        public ActionResult<IEnumerable<Utilisateur>> GetAll()
        {
            return seriesDbContext.Utilisateur.ToList();
        }
        public ActionResult<Utilisateur> GetById(int id)
        {
            return seriesDbContext.Utilisateur.FirstOrDefault(u => u.UtilisateurId == id);
        }
        public async Task<ActionResult<Utilisateur>> GetByStringAsync(string mail)
        {
            return await seriesDbContext.Utilisateur.FirstOrDefaultAsync(u => u.Mail.ToUpper() == mail.ToUpper());
        }
        public async Task AddAsync(Utilisateur entity)
        {
            await seriesDbContext.Utilisateur.AddAsync(entity);
            await seriesDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Utilisateur utilisateur, Utilisateur entity)
        {
            seriesDbContext.Entry(utilisateur).State = EntityState.Modified;
            utilisateur.UtilisateurId = entity.UtilisateurId;
            utilisateur.Nom = entity.Nom;
            utilisateur.Prenom = entity.Prenom;
            utilisateur.Mail = entity.Mail;
            utilisateur.Rue = entity.Rue;
            utilisateur.CodePostal = entity.CodePostal;
            utilisateur.Ville = entity.Ville;
            utilisateur.Pays = entity.Pays;
            utilisateur.Latitude = entity.Latitude;
            utilisateur.Longitude = entity.Longitude;
            utilisateur.Pwd = entity.Pwd;
            utilisateur.Mobile = entity.Mobile;
            utilisateur.NotesUtilisateur = entity.NotesUtilisateur;
            await seriesDbContext.SaveChangesAsync();
        }
        public async Task DeleteASync(Utilisateur utilisateur)
        {
            seriesDbContext.Utilisateur.Remove(utilisateur);
            await seriesDbContext.SaveChangesAsync();
        }
    }
}
