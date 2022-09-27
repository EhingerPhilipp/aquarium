using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquarium
{
    internal class Shark : Fish
    {
        public Shark(int x, int y)
        {
            Shape = "<///====><";
            ShapeReverse = @"><====\\\\>";
            PosX = x;
            PosY = y;
            Direction = "left";
            DepthChangeProbability = 4;
            DirectionChangeProbability = 50;
            Speed = 3;
        }

        public override void Swim(Aquarium aquarium)
        {
            //lokate me a target
            GetNearestFish(aquarium);
            //do the swimming
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
                    PosX = aquarium.Content.GetLength(1) - 1 - Shape.Length;
                }
                else
                {//normal swimming
                    PosX += Speed;
                }
            }
        }

        private void GetNearestFish(Aquarium aquarium)
        {
            //ugly shit
            Fish nearestFish = aquarium.Fishes[0];
            //set to random high value as easy entrypoint
            double distance = 9999999999999;

            foreach (Fish potentialTarget in aquarium.Fishes)
            {
                double potentialDistance = Math.Sqrt((potentialTarget.PosX - PosX) * (potentialTarget.PosX - PosX) + (potentialTarget.PosY - PosY) * (potentialTarget.PosY - PosY));
                if (potentialDistance < distance && potentialTarget != this)
                {
                    distance = potentialDistance;
                    nearestFish = potentialTarget;
                }
            }

            //define direction
            if(PosX > nearestFish.PosX)
            {
                Direction = "left";
            } else
            {
                Direction = "right";
            }
            //define height
            if (PosY > nearestFish.PosY)
            {
                PosY -= 1;
            }
            else
            {
                PosY += 1;
            }
        }
    }
}
