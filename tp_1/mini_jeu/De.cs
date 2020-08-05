using System;
using System.Collections.Generic;
using System.Text;

namespace mini_jeu
{
    static class De
    {
        public static Random DeALancer = new Random();
        public const int MultiplicateurBoss = 26;

        public static int LanceDeDe()
        {
            return DeALancer.Next(1, 7);
        }

        public static int LanceDeDe(int value)
        {
            return DeALancer.Next(1, value);
        }
    }
}
