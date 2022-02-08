using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{   

    internal class Player : GameObject
    {
        public enum Direction { Up, Down, Left, Right}

        public Direction playerDirection;
        public LinkedList<Position> Positions = new LinkedList<Position>();
        public Points points; //Points in The game and body count
        public int bodyParts = 0;

        //Standard mostly used in tests 
        public Player ()
        {
            points = new Points();  
            Position start = new Position { x = 3, y = 3};
            this.playerDirection = Direction.Down;
            position = start;
            Appearance = '☻';
            color = ConsoleColor.DarkRed;
            Positions.AddFirst(start);
        }
        public Player(Position start)
        {
            points = new Points();
            this.playerDirection = Direction.Down;
            position = start;
            Appearance = '☻';
            color = ConsoleColor.DarkRed;
            Positions.AddFirst(start);

        }
        public Player(Position start, Points p, char look = '☻', ConsoleColor c = ConsoleColor.Green)
        {
            points = p;
            this.playerDirection = Direction.Down;
            position = start;
            Appearance = look;
            color = c;
            Positions.AddFirst(start);
        }

        public override void Update()
        {
            Positions.AddFirst(this.position.Clone());

            //If the player has not gotten any point, we remove the last Position from the list to avoid a memory leak.
            if((Positions.Count - 1) > bodyParts)
                Positions.RemoveLast();

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
                           
            }
            

        }
    }
}
