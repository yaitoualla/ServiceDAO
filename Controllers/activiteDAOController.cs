using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceDAOREST.Models;



namespace WebServiceDAOREST.Controllers
{
    public class activiteDAOController : ApiController
    {
        // GET: api/activiteDAO
        public IEnumerable<Utilisateur> Get()
        {
            RegistreUtilisateurs monRegistre = new RegistreUtilisateurs();
            monRegistre = DAOMySQL.getList();

            return monRegistre.listing;
        }

        // GET: api/activiteDAO/5
        public Utilisateur Get(int id)
        {
            Utilisateur utilisateur = new Utilisateur();
            utilisateur = DAOMySQL.getUser(id);
            return utilisateur;
        }

        // POST: api/activiteDAO
        public int Post([FromBody]Utilisateur value)
        {
            DAOMySQL.insertUser(value);
            int numUser = DAOMySQL.getLastSequence("Utilisateur", "numUtilisateur");
            return numUser;
        }

        // PUT: api/activiteDAO/5
        public void Put([FromBody]Utilisateur value)
        {

           
            DAOMySQL.updateUser(value);

        }

        // DELETE: api/activiteDAO/5
        public void Delete(int id)
        {
            DAOMySQL.delUser(id);
        }
    }
}
