using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    /// <summary>
    /// Creating a static Food object at a position and with a Console Appearance
    /// </summary>
    internal class Food : GameObject
    {
        public Food(Position foodPosition)
        {
            position = foodPosition;
            Appearance = (char)15;
        }
        /// <summary>
        /// Static so it does not do anything ;)
        /// </summary>
        public override void Update()
        {

        }
    }
}
