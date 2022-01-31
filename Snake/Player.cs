using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{   
    //NotMoving Enum Global Variable, Own class ?,. 

    internal class Player : GameObject
    {
        public enum Direction { Up, Down, Left, Right, NotMoving }

        public Direction playerMove;
        //Needs a Start postion
        public Player (Position start)
        {
            this.playerMove = Direction.NotMoving;
            position = start;
            Appearance = 'X';
        }

        public override void Update()
        {
            switch (this.playerMove)
            {
                case Direction.Up:
                    position.x -= 1;
                    break;
                case Direction.Down:
                    position.x += 1;
                    break;
                case Direction.Left:
                    position.y -= 1;
                    break;
                case Direction.Right:
                    position.y += 1;
                    break;
                default:
                    position.x += 0;
                    position.y += 0;
                    break;                 
            }
        }
    }
}
