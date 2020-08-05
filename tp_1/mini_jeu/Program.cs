using System;
using System.Reflection.Metadata.Ecma335;

namespace mini_jeu
{
    class Program
    {
        private static readonly Random choixMonstre = new Random();

        static void Main()
        {
            Console.WriteLine("A quel jeu voulez vous jouer ? (1 : horde, 2: boss)");
            int choix = int.Parse(Console.ReadLine());
            if (choix == 1)
            {
                Jeu1();
            }
            else
            {
                Jeu2();
            }
        }       

        private static MonstreFacile CreateMonster()
        {
            return choixMonstre.Next(1) == 0 ? new MonstreFacile() : new MonstreDifficile();
        }

        private static void Jeu1()
        {
                Hero hero = new Hero(150);
                int monstreVaincuTotal = 0;
                int monstreVaincuFacile = 0;
                int monstreVaincuDifficile = 0;

                Console.WriteLine("Notre hero commence son combat contre la horde !");
                while (hero.EstVivant)
                {
                    MonstreFacile mechant = CreateMonster();
                    Console.WriteLine($"Un monstre de niveau {mechant.Type} apparait !");
                    while (mechant.EstVivant)
                    {
                        Console.WriteLine("Le hero s'élance et frappe !");
                        hero.Attaquer(mechant);
                        if (mechant.EstVivant)
                        {
                            Console.WriteLine("Le hero manque son coup ! L'ennemi se prepare à attaquer...");
                            mechant.Attaquer(hero);
                            if (!hero.EstVivant)
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Notre combattant d'elite ne fait qu'une bouché du vile monstre !");
                        }
                    }
                    if (mechant is MonstreDifficile)
                    {
                        monstreVaincuDifficile++;
                    }
                    else
                    {
                        monstreVaincuFacile++;
                    }
                    monstreVaincuTotal++;
                }
                Console.WriteLine($"Notre Hero meurt des suites de ses blessures. Il aura vaincu {monstreVaincuTotal} monstres avant de rendre l'âme dont {monstreVaincuDifficile} monstres difficle et {monstreVaincuFacile} monstres facile :( RIP");
        }

        private static void Jeu2()
        {
            Hero hero = new Hero(150);
            MonstreFacile boss = new Boss(250);

            Console.WriteLine($"Notre hero s'avance devant la menace et tombe nez à nez face à un {boss.Type} !");
            while (hero.EstVivant && boss.EstVivant )
            {
                Console.WriteLine("Le hero s'élance et frappe !");
                hero.Attaquer(boss);
                if(boss.EstVivant)
                {
                    Console.WriteLine("L'ennemi est puissant et frappe à son tour !");
                    boss.Attaquer(hero);
                }
            }
            Console.WriteLine(hero.EstVivant ? "Le boss sucombe face à notre héro sans peur !" : "Notre valeureux héro succombe face au formidable ennemi");
        }
    }
}
