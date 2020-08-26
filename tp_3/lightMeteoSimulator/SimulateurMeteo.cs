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
                    ProcessWeather(2);
                }
                else if(val >= 50 && val <= 90)
                {
                    ProcessWeather(0);
                }
                else
                {
                    ProcessWeather(1);
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
            //Console.WriteLine("event levé !");
        }

        // weather process: 0 or 1 = bad weather, 2 = sunny
        private void ProcessWeather(int weather = 0)
        {
            if (ChangementTemps != null)
            {
                Console.WriteLine(weather == 0 ? "il pleut" : weather == 1 ? "il ya orage" : "il fait beau");
                if(weather == 2)
                {
                    this.BeauTemps++;
                }
                else
                {
                    this.MauvaisTemps++;
                }
                ChangementTemps(this, new ChangementTempsEvent { BeauTemps = this.BeauTemps, MauvaisTemps = this.MauvaisTemps });
            }
        }
    }
}
