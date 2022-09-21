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
    }
}
