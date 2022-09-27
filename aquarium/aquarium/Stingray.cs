using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquarium
{
    public class Stingray : Fish
    {
        public Stingray(int x, int y)
        {
            Shape = "--<>";
            ShapeReverse = "<>--";
            PosX = x;
            PosY = y;
            Direction = "right";
            DepthChangeProbability = 5;
            DirectionChangeProbability = 50;
            Speed = 1;
        }
    }
}

