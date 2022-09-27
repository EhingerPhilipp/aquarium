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

        public virtual void Swim(Aquarium aquarium)
        {
            //see of the fishe changes depth or direction
            ChangeDirection(aquarium, DirectionChangeProbability);
            ChangeDepth(aquarium, DepthChangeProbability);
            //do actual swimming
            if (Direction == "left")
            {
                if (Shape.Length >= PosX - Speed)
                {//avoid walls
                    Direction = "right";
                    PosX = Shape.Length;
                }
                else
                {//normal swimming
                    PosX -= Speed;
                }
            }
            else
            {
                if (Shape.Length >= (aquarium.Content.GetLength(1) - PosX + Speed))
                {//avoid walls
                    Direction = "left";
                    PosX = aquarium.Content.GetLength(1) -1 - Shape.Length;
                }
                else
                {//normal swimming
                    PosX += Speed;
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
                    PosX += Shape.Length;
                }
                else
                {
                    Direction = "left";
                    PosX -= Shape.Length;
                }
            }
        }
        public void ChangeDepth(Aquarium aquarium, int probability)
        {
            if (aquarium.Random.Next(0, probability) == 1)
            {
                if (aquarium.Random.Next(0, 2) == 1 && PosY - 1 >= 0)
                {
                    PosY -= 1;
                }
                else if (PosY + 1 < aquarium.Content.GetLength(0) - 1)
                {
                    PosY += 1;
                }
            }
        }
    }
}
