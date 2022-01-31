using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{   

    internal class Player : GameObject
    {
        public enum Direction { Up, Down, Left, Right, NotMoving }

        public Direction playerDirection;
        //Needs a Start postion
        public Player ()
        {
            Position start = new Position { x = 3, y = 3};

            this.playerDirection = Direction.NotMoving;
            position = start;
            Appearance = '☻';
        }
        public Player(Position start)
        {

            this.playerDirection = Direction.NotMoving;
            position = start;
            Appearance = '☻';
        }

        public override void Update()
        {
            switch (this.playerDirection)
            {
                case Direction.Up:
                    position.y -= 1;
                    break;
                case Direction.Down:
                    position.y += 1;
                    break;
                case Direction.Left:
                    position.x -= 1;
                    break;
                case Direction.Right:
                    position.x += 1;
                    break;
                default:
                    position.x += 0;
                    position.y += 0;
                    break;                 
            }
        }
    }
}
