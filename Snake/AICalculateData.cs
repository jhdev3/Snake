using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
     struct AICalculateData
    {
        public readonly Player.Direction direction;
        public readonly int distance;

        public AICalculateData(Player.Direction d, int value)
        { 
            direction = d;
            distance = value;   
        }
    }
}
