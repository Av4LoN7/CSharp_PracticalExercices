using System;

namespace GenericChainList
{
    class Program
    {
        static void Main(string[] args)
        {
            ChainList<int> test = new ChainList<int>();

            test.Ajouter(10);
            test.Ajouter(5);
            test.Ajouter(32);
            test.Ajouter(14);
            test.InsererMaillon(7, 2);
            Console.WriteLine(test.RecupererMaillon(0).Value);
            Console.WriteLine(test.RecupererMaillon(1).Value);
            Console.WriteLine(test.RecupererMaillon(2).Value);

            //Console.WriteLine(test.First.Next.Previous.Value);
            //Console.WriteLine(test.Last.Value);
            //Console.WriteLine(test.Last.Previous.Value);


        }
    }
}
