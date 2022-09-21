using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquarium
{
    public abstract class Fish
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public string Direction { get; set; }
        public string Shape { get; set; }
        public string ShapeReverse { get; set; }
        public int DepthChangeProbability { get; set; }
        public int DirectionChangeProbability { get; set; }
        public int Speed { get; set; }

        public void Swim(Aquarium aquarium)
        {
            //see of the fishe changes depth or direction
            ChangeDirection(aquarium, DirectionChangeProbability);
            ChangeDepth(aquarium, DepthChangeProbability);
            //do actual swimming
            if (Direction == "left")
            {
                if (Shape.Length >= PosY - Speed)
                {//avoid walls
                    Direction = "right";
                    PosY = Shape.Length;
                }
                else
                {//normal swimming
                    PosY -= Speed;
                }
            }
            else
            {
                if (Shape.Length >= (aquarium.Content.GetLength(1) - PosY + Speed))
                {//avoid walls
                    Direction = "left";
                    PosY = aquarium.Content.GetLength(1) -1 - Shape.Length;
                }
                else
                {//normal swimming
                    PosY += Speed;

                }
            }
        }
        public void ChangeDirection(Aquarium aquarium, int probability)
        {
            if (aquarium.Random.Next(0, probability) == 1)
            {
                if (Direction == "left")
                {
                    Direction = "right";
                    PosY += Shape.Length;
                }
                else
                {
                    Direction = "left";
                    PosY -= Shape.Length;
                }
            }
        }
        public void ChangeDepth(Aquarium aquarium, int probability)
        {
            if (aquarium.Random.Next(0, probability) == 1)
            {
                if (aquarium.Random.Next(0, 2) == 1 && PosX - 1 >= 0)
                {
                    PosX -= 1;
                }
                else if (PosX + 1 < aquarium.Content.GetLength(0) - 1)
                {
                    PosX += 1;
                }
            }
        }
    }
}
