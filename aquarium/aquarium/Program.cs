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
            Aquarium aquarium = new Aquarium(20, 90);
            aquarium.AddFish();
            aquarium.RenderAquarium();
            while (true)
            {
                Thread.Sleep(500);
                aquarium.Swim();
                aquarium.RenderAquarium();
            }
            



            //end of program
            Console.ReadLine();
        }
    }
}
