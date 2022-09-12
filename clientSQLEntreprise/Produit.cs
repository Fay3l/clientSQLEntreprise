using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientSQLEntreprise
{
    class Produit
    {
        private string couleurProduit;
        private string nomProduit;
        private int numeroProduit;
        private double poidsProduit;

        public string Couleur
        {
            get
            {
                return this.couleurProduit;
            }
        }
        public string Nom
        {
            get
            {
                return this.nomProduit;
            }
        }
        public int Numero
        {
            get
            {
                return this.numeroProduit;
            }
        }
        public double Poids
        {
            get
            {
                return this.poidsProduit;
            }
        }
        public Produit(int numero,string nom,double poids,string couleur)
        {
            this.couleurProduit = couleur;
            this.nomProduit = nom;
            this.numeroProduit = numero;
            this.poidsProduit = poids;
        }
    }
}
