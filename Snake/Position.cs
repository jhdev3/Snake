using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Position
    {//TEST
        public int x, y;

        public bool IsEqual(Position compare)
        {
            if(x == compare.x && y == compare.y)
            {
                return true;
            } 
            else
                return false;
        }
        public override string ToString()
        {
            return "X: " + x + " " + "Y: " + y;
        }

        public Position Clone()
        {
            Position result = new Position();
            result.x = x;
            result.y = y;
            return result;
        }

    }
}
