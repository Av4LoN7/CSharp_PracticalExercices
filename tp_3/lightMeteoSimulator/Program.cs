using System;

namespace lightMeteoSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nous devons créer un simulateur de météo.Lorsque celui-ci est démarré, il génère autant de nombres 
            //aléatoires que demandé, des nombres entre 0 et 100.
            //Si le nombre aléatoire est inférieur à 5, alors cela veut dire que le temps est au soleil.
            //S’il est supérieur ou égal à 5 et inférieur à 50, alors nous aurons des nuages.
            //S’il est supérieur ou égal à 50 et inférieur à 90, alors nous aurons de la pluie. Sinon, nous aurons de l’orage.
            //Un événement sera levé à chaque changement de temps.Le but de notre statisticien est de s’abonner aux événements du 
            //simulateur météo afin de compter le nombre de fois où il a fait soleil et le nombre de fois où le temps a 
            //changé. Il affichera ensuite son rapport en indiquant ces deux résultats et le pourcentage de fois où il a fait soleil. 
            //(Je veux bien que ce pourcentage soit un entier).
            new DemoEvent().Demo();
        }
    }

    public class DemoEvent
    {
        public void Demo()
        {
            SimulateurMeteo simu = new SimulateurMeteo(10);
            simu.GenerateMeteo();
            simu.ShowStatMeteo();
            simu.ShowPourcentage();
        }
    }
}
