using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class PlayerBodyPart : GameObject
    {
        public int PosInPlayerList;
        public Player Player; 
        public PlayerBodyPart(int step, Player player)
        {
            PosInPlayerList = step;
            Player = player;
            Appearance = '#';
            color = player.color;
        }


        public override void Update()
        {
            this.position = Player.Positions.ElementAt(PosInPlayerList);
        }
    }
}
