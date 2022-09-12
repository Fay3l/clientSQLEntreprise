using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientSQLEntreprise
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                    //Data Source = LAPTOP - RNC81ILS\sqlexpress; Initial Catalog = Entreprise2020; User ID = snir2Entreprise; Password = @Password1234!
                    Entreprise2020 entreprise1 = new Entreprise2020(Environment.MachineName, "Entreprise2020", "snir2Entreprise", "@Password1234!");
                    Console.WriteLine("connection etablie\n");
                List<Produit> ListeProduit = entreprise1.ListeProduit();
                List<string> nomcolonne = entreprise1.NomColonnesProduit();
                foreach (string col in nomcolonne)
                {
                    Console.Write(col + "\t\t");
                }
                Console.WriteLine();

                foreach (Produit p1 in ListeProduit)
                {
                    Console.WriteLine(p1.Numero.ToString() + "\t\t" + p1.Nom + p1.Poids.ToString() + "\t\t" + p1.Couleur);
                }
                int NbMax = entreprise1.NPMax(); 
                Produit p = new Produit(NbMax+1, "PC bureau", 2.1, "rouge");
                int Ajout = entreprise1.AjouterProduit(p);
                ListeProduit = entreprise1.ListeProduit();
                nomcolonne = entreprise1.NomColonnesProduit();
                foreach (string col in nomcolonne)
                {
                    Console.Write(col+"\t\t");
                }
                Console.WriteLine();

                foreach (Produit p1 in ListeProduit )
                {
                    Console.WriteLine(p1.Numero.ToString()+ "\t\t" + p1.Nom  + p1.Poids.ToString()+ "\t\t" + p1.Couleur);
                }
                
                

               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message,"Erreur");
            }

            
        }
    }
}
