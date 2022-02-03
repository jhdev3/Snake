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
        public Player Player; 
        public PlayerBody(int step, Player player)
        {
            Step = step;
            Appearance = '#';
            Player = player;
        }


        public override void Update()
        {
            this.position = Player.Positions.ElementAt(Step);
        }
    }
}
