using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Food : GameObject
    {
        public Food(Position foodPosition)
        {
            position = foodPosition;
            Appearance = '@';
        }
        public override void Update()
        {

        }
    }
}
