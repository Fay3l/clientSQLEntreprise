using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientSQLEntreprise
{
    class Entreprise2020
    {
        private string chaineConnection;

        public Entreprise2020(string hote,string BdD,string Utilisateur,string MdP)
        {
            try
            {
                //Data Source = LAPTOP-RNC81ILS\sqlexpress; Initial Catalog = Entreprise2020; User ID = snir2Entreprise; Password = ***********
                string chaine;
                SqlConnection cnn; 
                chaine = @"Data Source="+hote+ @"\sqlexpress;Initial Catalog=" + BdD+";User ID="+Utilisateur+";Password="+MdP;
                cnn = new SqlConnection(chaine);
                cnn.Open();
                this.chaineConnection = chaine;
                cnn.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
        public List<Produit> ListeProduit()
        {
            List<Produit> ListeProduit = new List<Produit>();
            SqlConnection connection = new SqlConnection(chaineConnection);
            SqlDataReader reader = null;

            try
            {
                
                
                SqlCommand command = new SqlCommand("SELECT * FROM P", connection);
                
                    connection.Open();
                     reader = command.ExecuteReader();
                    
                        if(reader.HasRows)
                        {
                            while (reader.Read())

                            {
                                Produit p = new Produit(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3));
                                ListeProduit.Add(p);
                                
                            }
                        }
                      
                    
                
                return ListeProduit ;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (connection != null)
                    connection.Close();
           
            }
           
        }
        public List<string> NomColonnesProduit()
        {
            
            List<string> Colonnes = new List<string>();
            SqlConnection connection = new SqlConnection(chaineConnection);
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM P", connection);
                connection.Open();
                reader = command.ExecuteReader();
                for(int col = 0; col< reader.FieldCount; col++)
                {
                    Colonnes.Add(reader.GetName(col));
                }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (connection != null)
                    connection.Close();
                
            }
           

            return Colonnes;
        }
        public int AjouterProduit(Produit p)
        {
            string format = "C";
            //List<Produit> produit = new List<Produit>();
        
            SqlConnection connection = new SqlConnection(chaineConnection);
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            try
            {
                
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO P (NP ,nomP ,poids ,couleur) VALUES(" + p.Numero + ",'" + p.Nom + "'," + p.Poids.ToString(format, culture) + ",'" + p.Couleur + "')", connection);
                return command.ExecuteNonQuery();
                

                //connection.Open();
                //SqlDataReader reader = command.ExecuteReader();
                //if (reader.HasRows)
                //{
                //    while (reader.Read())
                //    {
                //      return produit;
                //        produits.Add(p);
                //    }
                //}
                
                 
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
           
            
        }

        public int NPMax()
        {
            int np;
            SqlConnection connection = new SqlConnection(chaineConnection);
            try
            {
                SqlCommand command = new SqlCommand("SELECT MAX(NP) FROM P", connection);
                connection.Open();
                np = Convert.ToInt32(command.ExecuteScalar());
                return np; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        public quantiteLivreParRefResultat QuantiteLivreeParReference(int reference)
        {
            SqlConnection connection = new SqlConnection(chaineConnection);
            quantiteLivreParRefResultat resultat = new quantiteLivreParRefResultat();
            try
            {
                SqlCommand command = new SqlCommand("quantiteLivreeeParRef", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter np = new SqlParameter("@NP1", reference);
                np.Direction = System.Data.ParameterDirection.Input;


                command.Parameters.Add(np);
                int r= command.ExecuteNonQuery();

                resultat.retour = r;
                if (r == 0)
                    resultat.quantite =Convert.ToInt32( command.Parameters[1].Value);
                return resultat ; 
            }
            catch(Exception ex)
            {
                throw ex; 
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            
        }
    }
}
