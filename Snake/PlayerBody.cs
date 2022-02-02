using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class PlayerBody : GameObject
    {
        public int Step;
        public PlayerBody(int step)
        {
            Step = step;
            Appearance = '#';
        }


        public override void Update()
        {
            
        }
    }
}
