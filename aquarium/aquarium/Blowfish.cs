using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquarium
{
    public class Blowfish : Fish
    {
        public Blowfish(int x, int y)
        {
            Shape = "<()><";
            ShapeReverse = "><()>";
            PosX = x;
            PosY = y;
            Direction = "left";
            DepthChangeProbability = 10;
            DirectionChangeProbability = 50;
            Speed = 1;
        }
    }
}
