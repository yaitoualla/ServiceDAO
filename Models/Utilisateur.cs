using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace WebServiceDAOREST.Models
{
    [DataContract]
    public class Utilisateur
    {

        [DataMember(Name = "numUtilisateur")]
        public int numUtilisateur { get; set; }
        [DataMember(Name = "nomUtilisateur")]
        public string nomUtilisateur { get; set; }
        [DataMember(Name = "prenomUtilisateur")]
        public string prenomUtilisateur { get; set; }
        [DataMember(Name = "dateNaissance")]
        public DateTime dateNaissance { get; set; }
        [DataMember(Name = "age")]
        public int age { get; set; }
        [DataMember(Name = "timeStamp")]
        public DateTime timeStamp { get; set; }
        [DataMember(Name = "nomMachine")]
        public string nomMachine { get; set; }
        [DataMember(Name = "activite")]
        public string activite { get; set; }
        
        public Utilisateur()
        {

        }

        public override string ToString()
        {
            return prenomUtilisateur + " " + numUtilisateur;
        }




    }
}