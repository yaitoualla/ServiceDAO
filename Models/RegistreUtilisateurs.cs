using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceDAOREST.Models
{
    public class RegistreUtilisateurs
    {
        public List<Utilisateur> listing { get; set; }

        public RegistreUtilisateurs()
        {
            listing = new List<Utilisateur>();
        }
        public void ajouterUtilisateur(Utilisateur utilisateur)
        {
            listing.Add(utilisateur);
        }

    }
}