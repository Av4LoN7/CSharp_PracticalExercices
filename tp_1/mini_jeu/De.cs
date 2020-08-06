using System;
using System.Collections.Generic;
using System.Text;

namespace mini_jeu
{
    static class De
    {
        public static Random DeALancer = new Random();
        public static int LanceDeDe() => DeALancer.Next(1, 7);
        public static int LanceDeDe(int value) => DeALancer.Next(1, value);
    }
}
