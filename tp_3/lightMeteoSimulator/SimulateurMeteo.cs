using System;
using System.Collections.Generic;
using System.Text;

namespace lightMeteoSimulator
{
    public class SimulateurMeteo
    {
        public int Multiplicateur { get; private set; }
        public List<int> Meteo = new List<int>();
        private readonly Random Random = new Random();

        public EventHandler<ChangementTempsEvent> ChangementTemps;
        public int BeauTemps { get; set; }
        public int MauvaisTemps { get; set; }

        public SimulateurMeteo(int value)
        {
            this.Multiplicateur = value;
            this.BeauTemps = this.MauvaisTemps = 0;
        }

        public void GenerateMeteo()
        {
            for (int i = 0; i < this.Multiplicateur; i++)
            {
                int valTemp = this.Random.Next(0, 100);
                this.Meteo.Add(valTemp);
            }
            ChangementTemps += TriggerEvent;
        }

        public void ShowStatMeteo()
        {
            foreach(int val in this.Meteo)
            {
                if(val >= 5 && val < 50)
                {
                    Console.WriteLine("il fait beau");
                    if(ChangementTemps != null)
                    {
                        this.BeauTemps++;
                        ChangementTemps(this, new ChangementTempsEvent { BeauTemps = this.BeauTemps, MauvaisTemps = this.MauvaisTemps });
                    }
                }
                else if(val >= 50 && val <= 90)
                {
                    Console.WriteLine("il pleut");
                    if (ChangementTemps != null)
                    {
                        this.MauvaisTemps++;
                        ChangementTemps(this, new ChangementTempsEvent { BeauTemps = this.BeauTemps, MauvaisTemps = this.MauvaisTemps });
                    }
                }
                else
                {
                    Console.WriteLine("il y a de l'orage");
                    if (ChangementTemps != null)
                    {
                        this.MauvaisTemps++;
                        ChangementTemps(this, new ChangementTempsEvent { BeauTemps = this.BeauTemps, MauvaisTemps = this.MauvaisTemps });
                    }
                }
            }
        }

        public void ShowPourcentage()
        {
            Console.WriteLine($"il à fait beau {this.BeauTemps} fois. Il à fait beau {(this.BeauTemps * 100) / this.Multiplicateur}% du temps");
            Console.WriteLine($"le temps a changé {this.MauvaisTemps} fois");
        }

        private void TriggerEvent(object sender, ChangementTempsEvent e)
        {
            Console.WriteLine("event levé !");
        }
    }
}
