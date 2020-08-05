using System;
using System.Collections.Generic;
using System.Text;

namespace mini_jeu
{
    class Boss : MonstreFacile
    {
        public int PointDeVie { get; private set; }
        public bool BossVivant
        {
            get { return this.PointDeVie > 0; }
        }

        public Boss(int pointDeVie)
        {
            this.PointDeVie = pointDeVie;
            this.Type = "Boss";
        }

        public void SubitDegat(int nbrDegat)
        {
            this.PointDeVie -= nbrDegat;
            Console.WriteLine($"Le Boss subit {nbrDegat} pts de degats");
        }

        public override void Attaquer(Hero target)
        {
            target.SubitDegat(this.LanceDeDe(26));
        }

        public int LanceDeDe(int valeur)
        {
            return De.LanceDeDe(valeur);
        }
    }
}
