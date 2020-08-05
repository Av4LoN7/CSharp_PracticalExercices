using System;
using System.Collections.Generic;
using System.Text;

namespace mini_jeu
{
    class MonstreDifficile : MonstreFacile
    {
        private const int Multiplicateur = 5;
        public MonstreDifficile() 
        {
            this.Type = "Difficile";
        }
        public override void Attaquer(Hero target)
        {
            base.Attaquer(target);
            if (target.EstVivant) {
                int AttaqueMagique = De.LanceDeDe();
                if (AttaqueMagique != 6) {
                    Console.WriteLine("Au mon dieu le monstre enchaine avec une attaque magique dévastatrice");
                    target.SubitDegat(AttaqueMagique * Multiplicateur);
                }
            }
        }
    }
}
