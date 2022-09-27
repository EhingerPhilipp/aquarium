using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquarium
{
    public class Aquarium
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string[,] Content { get; set; }
        public List<Fish> Fishes { get; set; }
        public Random Random { get; set; }
        public Aquarium(int width, int height)
        {
            Width = width;
            Height = height;
            Content = new string[Width, Height];
            Fishes = new List<Fish>();
            Random = new Random();
        }

        public void RenderAquarium()
        {   //draw empty aquarium
            PrepareAquarium();

            //render the fishes
            PrepareFishes();

            //print on console
            PrintAquarium();
        }

        public void PrepareAquarium()
        {
            for (int j = 0; j < Content.GetLength(0); j++)
            {
                for (int i = 0; i < Content.GetLength(1); i++)
                {
                    Content[j, i] = "~";

                    if (j == Content.GetLength(0) - 1 && (i == Content.GetLength(1) - 1 || i == 0))
                    {
                        Content[j, i] = "+";
                    }
                    else if (i == 0 || i == Content.GetLength(1) - 1)
                    {
                        Content[j, i] = "|";
                    }
                    else if (j == Content.GetLength(0) - 1)
                    {
                        Content[j, i] = "-";
                    }
                }
            }
        }

        public void PrepareFishes()
        {
            for (int f = 0; f < Fishes.Count; f++)
            {
                Fish fish = Fishes[f];
                int x = fish.PosX;
                string shape = fish.Shape;
                
                //turn the fish around for nicer looks
                if (fish.Direction == "right")
                {
                    x -= shape.Length - 1;
                    shape = fish.ShapeReverse;
                }


                foreach (char c in shape)
                {
                    //check if fish is in the way
                    if (Content[fish.PosY, x] != "~")
                    {
                        handleCollision(fish, x, fish.PosY);                     
                        f = 0;
                        //important to break before drawing another character into the array, this leads to unwanted bugs (and many tears while debugging)
                        break;
                    }

                    Content[fish.PosY, x] = Char.ToString(c);                  
                    x++;
                }
            }
        }

        private void PrintAquarium()
        {
            Console.Clear();
            for (int i = 0; i < Content.GetLength(0); i++)
            {
                for (int j = 0; j < Content.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (Content[i, j])
                    {
                        case "~":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                    }
                    Console.Write(Content[i, j]);
                }
                Console.Write("\n");
            }
        }

        public void AddFish()
        {
            Fishes.Add(new Carp(5, 2));                              
            Fishes.Add(new Carp(20, 4));                              
            Fishes.Add(new Carp(30, 4));                              
            Fishes.Add(new Carp(40, 4));                              
            Fishes.Add(new Carp(50, 4));                              
            Fishes.Add(new Carp(60, 4));                              
            Fishes.Add(new Carp(70, 4));                              
            Fishes.Add(new Carp(80, 4));                              
            Fishes.Add(new Shark(60, 2));
            Fishes.Add(new Shark(70, 2));
            Fishes.Add(new Blowfish(10, 15));
            Fishes.Add(new Blowfish(20, 15));
            Fishes.Add(new Blowfish(30, 15));
            Fishes.Add(new Blowfish(40, 15));
            Fishes.Add(new Blowfish(50, 15));
            Fishes.Add(new Blowfish(60, 15));
            Fishes.Add(new Blowfish(70, 15));
            Fishes.Add(new Blowfish(80, 15));
            Fishes.Add(new Swordfish(10, 10));
            Fishes.Add(new Swordfish(20, 10));
            Fishes.Add(new Swordfish(30, 10));
            Fishes.Add(new Swordfish(40, 10));
            Fishes.Add(new Swordfish(50, 10));
            Fishes.Add(new Swordfish(60, 10));
            Fishes.Add(new Swordfish(70, 10));
        }

        public void Swim()
        {
            foreach (Fish fish in Fishes)
            {
                fish.Swim(this);
            }
        }
        
        public void handleCollision(Fish fish, int x, int y)
        {
            //there be dragons
            //find me the next fish
            Fish collidingFish = null;
            int xLeft = x;
            int xRight = x;

            while (collidingFish == null)
            {
                foreach (Fish potentialFish in Fishes.Where(w => w.PosY == fish.PosY).Select(s => s).ToList())
                {

                    if ((potentialFish.PosY == y) && (potentialFish.PosX == xLeft || potentialFish.PosX == xRight) && potentialFish != fish)
                    {
                        collidingFish = potentialFish;
                        break;
                    }
                }
                xLeft--;
                xRight++;
            }

            //there is always a bigger fish, so remove the smaller ones
            if (fish.GetType().Name == collidingFish.GetType().Name)
            {
                Type fishType = fish.GetType();
                Fish newFish = (Fish)Activator.CreateInstance(fishType, 20, 20);
                Fishes.Add(newFish);
            }
            else if(fish.Shape.Length >= collidingFish.Shape.Length)
            {
                Fishes.Remove(collidingFish);
            } else
            {
                Fishes.Remove(fish);
            }

            //clear aquarium
            PrepareAquarium();
        }
    }
}
