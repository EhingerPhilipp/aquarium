using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquarium
{
    public class Swordfish : Fish
    {
        public Swordfish(int x, int y)
        {
            Shape = "-<><";
            ShapeReverse = "><>-";
            PosX = x;
            PosY = y;
            Direction = "left";
            DepthChangeProbability = 5;
            DirectionChangeProbability = 50;
            Speed = 1;
        }
    }
}
