using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class PlayerBodyPart : GameObject
    {
        /// <summary>
        /// Posistion sets on bodypart according to were it is positioned in players linkedlist 
        /// </summary>
        public int PosInPlayerList;
        public Player Player; 
        public PlayerBodyPart(int step, Player player)
        {
            PosInPlayerList = step;
            Player = player;
            Appearance = '#';
            color = player.color;
            player.bodyParts++;
            Update(); //Setting the position :)
        }


        public override void Update()
        {
            this.position = Player.Positions.ElementAt(PosInPlayerList);
        }
    }
}
