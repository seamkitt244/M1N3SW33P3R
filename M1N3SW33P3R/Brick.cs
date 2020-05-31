using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1N3SW33P3R
{
    class Brick
    {
        public static int X, Y, brickSize;
        public Brick(int _blockX, int _blockY, int _blockSize)//constructor method
        {
                X = _blockX;
                Y = _blockY;
                brickSize = _blockSize;
        }
    }
}
