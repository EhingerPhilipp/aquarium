using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen zu unserer Aquariumssimulation");
            int height = 0;
            do
            {
                Console.WriteLine("Wie hoch soll dein Aquarium sein?");
                height = Convert.ToInt32(Console.ReadLine());
                if (height < 20)
                {
                    Console.WriteLine("Bitte achte auf den Tierschutz ... ein Aquarium sollte auf jeden Fall 20 hoch sein");
                }
            } while (height < 20);

            
            int width = 0;
            do
            {
                Console.WriteLine("Wie breit soll dein Aquarium sein?");
                width = Convert.ToInt32(Console.ReadLine());
                if (width < 90)
                {
                    Console.WriteLine("Bitte achte auf den Tierschutz ... ein Aquarium sollte auf jeden Fall 90 breit sein");
                }
            } while (width < 90);

            Aquarium aquarium = new Aquarium(height, width);
            aquarium.AddFish();
            aquarium.RenderAquarium();
            while (aquarium.Fishes.Count > 1)
            {
                Thread.Sleep(500);
                aquarium.Swim();
                aquarium.RenderAquarium();
            }

            Console.WriteLine("In deinem Aquarium sind zu viele Fische gestorben :(");
            



            //end of program
            Console.ReadLine();
        }
    }
}
