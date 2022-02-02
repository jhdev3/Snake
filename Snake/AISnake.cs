using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Amazing AI Snake ;) 
namespace Snake
{
    internal class AISnake : Player
    {
        private GameWorld _AIWorld;
        //private Direction _AIDirection;
        public AISnake(GameWorld world, Position start, char look = 'A')
        {
             position = start;
             Appearance = look;
            _AIWorld = world;
            this.playerDirection = Direction.Up;


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
