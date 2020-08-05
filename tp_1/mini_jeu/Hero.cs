using System;
using System.Collections.Generic;
using System.Text;

namespace mini_jeu
{
    class Hero
    {
        public int PointDeVie { get; private set; }

        public bool EstVivant
        {
            get { return this.PointDeVie > 0; }
        }

        public Hero(int life)
        {
            this.PointDeVie = life;
        }

        public void Attaquer(MonstreFacile target)
        {
            if (this.LanceDeDe() >= target.LanceDeDe())
            {
                target.EstVaincu();
            }
        }

        public void Attaquer(Boss target) 
        {
            target.SubitDegat(this.LanceDeDe(26));
            if (!target.BossVivant)
            {
                target.EstVaincu();
            }
        }

        public void SubitDegat(int nombreDegat)
        {
            if(!this.BouclierFonctionnel()) {
                this.PointDeVie -= nombreDegat;
                Console.WriteLine($"Le hero subit {nombreDegat} pts de degats");
            }
            else {
                Console.WriteLine("Notre sauveur ne subit aucun dégat grâce à l'utilisation de son fidèle bouclier !");
            }
        }

        public bool BouclierFonctionnel()
        {
            return this.LanceDeDe() <= 2;
        }

        public int LanceDeDe()
        {
            return De.LanceDeDe();
        }

        public int LanceDeDe(int valeur)
        {
            return De.LanceDeDe(valeur);
        }

    }
}
