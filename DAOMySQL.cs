using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceDAOREST.Models;

namespace WebServiceDAOREST
{
    public static class DAOMySQL
    {
        public static string cs = "server = localhost; user = root;password=;database = UtilisateurActivite; port = 3306";

        public static MySqlConnection connection = new MySqlConnection(cs);

        public static string insertUser(Utilisateur user)
        {

            try
            {
                connection.Open();

                MySqlCommand sql = new MySqlCommand("insert into Utilisateur values (null,@paraNom,@paraPrenom,@paraDateNaissance,@paraAge,@paraTimeStamp,@paraNomMachine,@paraActivite);", connection);
                MySqlParameter[] parametre = new MySqlParameter[7];

                parametre[0] = new MySqlParameter("@paraNom", user.nomUtilisateur);
                parametre[1] = new MySqlParameter("@paraPrenom", user.prenomUtilisateur);
                parametre[2] = new MySqlParameter("@paraDateNaissance", user.dateNaissance);
                parametre[3] = new MySqlParameter("@paraAge", user.age);
                parametre[4] = new MySqlParameter("@paraTimeStamp", user.timeStamp);
                parametre[5] = new MySqlParameter("@paraNomMachine", user.nomMachine);
                parametre[6] = new MySqlParameter("@paraActivite", user.activite);


                for (int j = 0; j < parametre.Length; j++)
                { sql.Parameters.Add(parametre[j]); }



                sql.ExecuteNonQuery();
                return "Enregistrement de " + user.numUtilisateur + " reussi";
            }
            catch (Exception e)
            {
                return e.Message;


            }
            finally
            {
                connection.Close();
            }
        }
        public static int getLastSequence(string table, string colonne)
        {

            string requete = "select max(" + colonne + ") from " + table + ";";

            try
            {
                connection.Open();
                MySqlCommand sql = new MySqlCommand(requete, connection);


                sql.ExecuteNonQuery();

                return int.Parse(sql.ExecuteScalar().ToString());
            }
            catch (Exception e)
            {

                return -1;

            }
            finally
            {
                connection.Close();
            }


        }
        public static Boolean delUser(int numUser)
        {
            string requete = "delete from Utilisateur where numUtilisateur = @paraNum;";

            try
            {
                connection.Open();
                MySqlCommand sql = new MySqlCommand(requete, connection);
                MySqlParameter[] parametre = new MySqlParameter[1];
                parametre[0] = new MySqlParameter("@paraNum", numUser);

                for (int j = 0; j < parametre.Length; j++)
                { sql.Parameters.Add(parametre[j]); }

                sql.ExecuteNonQuery();
                return true;

            }
            catch (Exception e)
            {

                return false;

            }
            finally
            {
                connection.Close();
            }


        }

        public static Boolean updateUser(Utilisateur user)
        {
            string requete = "update Utilisateur set nomUtilisateur = @paraNom, prenomUtilisateur= @paraPrenom, " +
                "dateNaissance = @paraDateNaissance,age = @paraAge,timeStamp= @paraTimeStamp," +
                "nomMachine= @paraNomMachine, activite = @paraActivite where numUtilisateur = @paraNum;";

            try
            {
                connection.Open();
                MySqlCommand sql = new MySqlCommand(requete, connection);
                MySqlParameter[] parametre = new MySqlParameter[8];
                parametre[0] = new MySqlParameter("@paraNum", user.numUtilisateur);
                parametre[1] = new MySqlParameter("@paraNom", user.nomUtilisateur);
                parametre[2] = new MySqlParameter("@paraPrenom", user.prenomUtilisateur);
                parametre[3] = new MySqlParameter("@paraDateNaissance", user.dateNaissance);
                parametre[4] = new MySqlParameter("@paraAge", user.age);
                parametre[5] = new MySqlParameter("@paraTimeStamp", user.timeStamp);
                parametre[6] = new MySqlParameter("@paraNomMachine", user.nomMachine);
                parametre[7] = new MySqlParameter("@paraActivite", user.activite);


                for (int j = 0; j < parametre.Length; j++)
                { sql.Parameters.Add(parametre[j]); }


                sql.ExecuteNonQuery();
                return true;

            }
            catch (Exception e)
            {

                return false;

            }
            finally
            {
                connection.Close();
            }


        }
        public static RegistreUtilisateurs getList()
        {
            try
            {
                RegistreUtilisateurs List = new RegistreUtilisateurs();
                string requete = "select * from Utilisateur;";

                connection.Open();
                MySqlCommand sql = new MySqlCommand(requete, connection);

                MySqlDataReader reader = sql.ExecuteReader();

                for (int i = 0; reader.Read(); i++)
                {
                    Utilisateur utilisateur = new Utilisateur();
                    utilisateur.numUtilisateur = reader.GetInt32(0);
                    utilisateur.nomUtilisateur = reader.GetString(1);
                    utilisateur.prenomUtilisateur = reader.GetString(2);
                    utilisateur.dateNaissance = reader.GetDateTime(3);
                    utilisateur.age = reader.GetInt32(4);
                    utilisateur.timeStamp = reader.GetDateTime(5);
                    utilisateur.nomMachine = reader.GetString(6);
                    utilisateur.activite = reader.GetString(7);

                    List.ajouterUtilisateur(utilisateur);

                }
                return List;
            }
            catch (Exception e)
            {

                return null;
            }
            finally { connection.Close(); }
        }
        public static Utilisateur getUser(int numUser)
        {
            try
            {
                Utilisateur utilisateur = new Utilisateur();
                string requete = "select * from Utilisateur where numUtilisateur = @paraNum;";

                connection.Open();
                MySqlCommand sql = new MySqlCommand(requete, connection);
                MySqlParameter[] parametre = new MySqlParameter[1];
                parametre[0] = new MySqlParameter("@paraNum", numUser);
                for (int j = 0; j < parametre.Length; j++)
                { sql.Parameters.Add(parametre[j]); }
                MySqlDataReader reader = sql.ExecuteReader();

                for (int i = 0; reader.Read(); i++)
                {

                    utilisateur.numUtilisateur = reader.GetInt32(0);
                    utilisateur.nomUtilisateur = reader.GetString(1);
                    utilisateur.prenomUtilisateur = reader.GetString(2);
                    utilisateur.dateNaissance = reader.GetDateTime(3);
                    utilisateur.age = reader.GetInt32(4);
                    utilisateur.timeStamp = reader.GetDateTime(5);
                    utilisateur.nomMachine = reader.GetString(6);
                    utilisateur.activite = reader.GetString(7);


                }
                return utilisateur;
            }
            catch (Exception e)
            {

                return null;
            }
            finally { connection.Close(); }
        }
    }
}
