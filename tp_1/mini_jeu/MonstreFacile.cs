using System;
using System.Collections.Generic;
using System.Text;

namespace mini_jeu
{
    class MonstreFacile
    {
        public bool EstVivant { get; private set; }
        public string Type { get; protected set; }
        private const int Degat = 10;

        public MonstreFacile()
        {
            this.EstVivant = true;
            this.Type = "Facile";
        }
        
        public virtual void Attaquer(Hero target)
        {
            if (this.LanceDeDe() > target.LanceDeDe()) {
                target.SubitDegat(Degat);
            }
            else {
                Console.WriteLine("Lennemi rate son coup mouhahahahah");
            }
        }
        public void EstVaincu()
        {
            this.EstVivant = false;
        }

        public int LanceDeDe()
        {
            return De.LanceDeDe();
        }
    }
}
