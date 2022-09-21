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
            //render the fishes
            foreach (Fish fish in Fishes)
            {
                int y = fish.PosY;
                string shape = fish.Shape;
                if (fish.Direction == "right")
                {
                    y -= shape.Length - 1;
                    
                    shape = fish.ShapeReverse;
                }
                

                foreach (char c in shape)
                {
                    Content[fish.PosX, y] = Char.ToString(c);
                    y++;
                }
            }

            //print on console
            PrintAquarium();
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
            Fishes.Add(new Carp(4, 5));
            
            Fishes.Add(new Shark(6, 19));
            Fishes.Add(new Blowfish(8, 15));
            Fishes.Add(new Swordfish(3, 15));
        }

        public void Swim()
        {
            foreach (Fish fish in Fishes)
            {
                fish.Swim(this);
            }
        }
    }
}
