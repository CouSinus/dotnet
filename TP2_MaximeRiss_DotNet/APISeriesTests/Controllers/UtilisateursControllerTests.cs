using APISeries.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace APISeries.Controllers.Tests
{
    [TestClass()]
    public class UtilisateursControllerTests
    {

        private readonly SeriesDBContext _context;
        private readonly UtilisateursController _controller;

        [TestMethod()]
        public void GetUtilisateurTest()
        {
            //given 
            var resultContext = _context.Utilisateur.ToListAsync().Result;
            //when
            IEnumerable<Utilisateur> resultController = _controller.GetUtilisateur().Result.Value;
            //then

            bool condition = resultContext.Count == resultController.Count();

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void GetUtilisateurByIdSuccess()
        {
            //given 
            Utilisateur resultContext = (Utilisateur)_context.Utilisateur.Where(u => u.UtilisateurId == 1);
            //when
            Utilisateur resultController = _controller.GetUtilisateurById(1).Result.Value;
            //then

            bool condition = resultContext.Mail == resultController.Mail;

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void GetUtilisateurByIdFail()
        {
            //given 
            Utilisateur resultContext = (Utilisateur)_context.Utilisateur.Where(u => u.UtilisateurId == 2);
            //when
            Utilisateur resultController = _controller.GetUtilisateurById(1).Result.Value;
            //then

            bool condition = resultContext.Mail == resultController.Mail;

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void GetUtilisateurByEmailSuccess()
        {
            //given 
            Utilisateur resultContext = (Utilisateur)_context.Utilisateur.Where(u => u.Mail == "clilleymd@last.fm");
            //when
            Utilisateur resultController = _controller.GetUtilisateurByEmail("clilleymd@last.fm").Result.Value;
            //then

            bool condition = resultContext.UtilisateurId == resultController.UtilisateurId;

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void GetUtilisateurByEmailFail()
        {
            //given 
            Utilisateur resultContext = (Utilisateur)_context.Utilisateur.Where(u => u.Mail == "toto@last.fm");
            //when
            Utilisateur resultController = _controller.GetUtilisateurByEmail("clilleymd@last.fm").Result.Value;
            //then

            bool condition = resultContext.UtilisateurId == resultController.UtilisateurId;

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void Postutilisateur_ModelValidated_CreationOK()
        {
            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
            // Le mail doit être unique donc 2 possibilités :
            // 1. on s'arrange pour que le mail soit unique en concaténant un random ou un timestamp
            // 2. On supprime le user après l'avoir créé. Dans ce cas, nous avons besoin d'appeler la méthode DELETE du WS=> la décommenter
            Utilisateur userAtester = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0606070809",
                Mail = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var result = _controller.PostUtilisateur(userAtester).Result; 
            // .Result pour appeler la méthode async de manière synchrone, afin d'obtenir le résultat
            var result2 = _controller.GetUtilisateurByEmail(userAtester.Mail);
            var actionResult = result2.Result as ActionResult<Utilisateur>;
            // Assert
            Assert.IsInstanceOfType(actionResult.Value, typeof(Utilisateur), "Pas un utilisateur");
            Utilisateur? userRecupere = _context.Utilisateur.Where(u => u.Mail.ToUpper() ==
           userAtester.Mail.ToUpper()).FirstOrDefault();
            // On ne connait pas l'ID de l’utilisateur envoyé car numéro automatique.
            // Du coup, on récupère l'ID de celui récupéré et on compare ensuite les 2 users
            userAtester.UtilisateurId = userRecupere.UtilisateurId;
            Assert.AreEqual(userRecupere, userAtester, "Utilisateurs pas identiques");
        }
}