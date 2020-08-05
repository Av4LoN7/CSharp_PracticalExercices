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
            if(target is Boss boss) {
                boss.SubitDegat(De.LanceDeDe(De.MultiplicateurBoss));
                if(!boss.BossVivant)
                {
                    boss.EstVaincu();
                }
            }
            else  {
                if(this.LanceDeDe() >= target.LanceDeDe())
                {
                    target.EstVaincu();
                }
            }
        }

        public void SubitDegat(int nombreDegat)
        {
            if(!this.BouclierFonctionnel()) {
                this.PointDeVie -= nombreDegat;
                Console.WriteLine($"Le hero subit {nombreDegat} pts de degats");
            }
            else {
                Console.WriteLine("Notre sauveur ne subit aucun degat grace à l'utilisation de son fidele bouclier !");
            }
        }

        public bool BouclierFonctionnel()
        {
            return De.LanceDeDe() >= 2;
        }

        public int LanceDeDe()
        {
            return De.LanceDeDe();
        }

    }
}
